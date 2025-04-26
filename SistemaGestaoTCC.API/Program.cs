using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaGestaoTCC.Application.Commands.Courses.CreateCourse;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using SistemaGestaoTCC.Infrastructure.Authentication;
using SistemaGestaoTCC.Infrastructure.Repositories;
using SistemaGestaoTCC.Infrastructure.Services;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


//ADICIONANDO CORS PARA PODER SER CONSUMINDO NO FRONT-END
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) 
            .AllowCredentials();
    });
});

//CONNECTION STRING
//var connection = builder.Configuration.GetConnectionString("SistemaTcc");
var connection = configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<SGTCCContext>(p => p.UseSqlServer(connection));

builder.Services.AddScoped<EmailService>();

builder.Services.AddScoped<TokenService>();

builder.Services.AddScoped<IPasswordResetTokenRepository, PasswordResetTokenRepository>();
//google
//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
//    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];

//    googleOptions.CallbackPath = new PathString("/signin-google");
//});

#region AUTENTICACAO JWT BEARER
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {


            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaGestaoTCC.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema Bearer."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
#endregion


#region INJECAO DE DEPENDENCIA
//mediator injecao de dependencia
builder.Services.AddMediatR(typeof(CreateCourseCommand));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//repositorios injecao de dependencia
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjetoAtividadeRepository, ProjetoAtividadeRepository>();
//builder.Services.AddScoped<IProjetoEntregaRepository, ProjetoEntregaRepository>();
builder.Services.AddScoped<IProjetoArquivoRepository, ProjetoArquivoRepository>();
builder.Services.AddScoped<IProjetoComentarioRepository, ProjetoComentarioRepository>();
builder.Services.AddScoped<IAtividadeComentarioRepository, AtividadeComentarioRepository>();
builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUsuarioProjetoRepository, UsuarioProjetoRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IBancaRepository, BancaRepository>();
builder.Services.AddScoped<IAvaliadorBancaRepository, AvaliadorBancaRepository>();
builder.Services.AddScoped<ICampoDocumentoRepository, CampoDocumentoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<INotasDocumentoAlunoRepository, NotasDocumentoAlunoRepository>();
builder.Services.AddScoped<INotaFinalAlunoRepository, NotaFinalAlunoRepository>();
//builder.Services.AddScoped<IProjetoEntregaRepository, ProjetoEntregaRepository>();
builder.Services.AddScoped<IAtividadeComentarioRepository, AtividadeComentarioRepository>();
builder.Services.AddScoped<IArquivoRepository, ArquivoRepository>();
builder.Services.AddScoped<IAnotacaoRepository, AnotacaoRepository>();
builder.Services.AddScoped<IBibliografiaRepository, BibliografiaRepository>();
builder.Services.AddScoped<ISeminarioRepository, SeminarioRepository>();

//service
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();


#endregion

builder.Services.AddHttpClient();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserActivationTokenRepository, UserActivationTokenRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//TODO alterar pasta
app.UseStaticFiles();
var folderName = configuration["Files:Directory"] ?? "UploadedFiles";

if (folderName != null)
{
    var folderPath = Path.Combine(builder.Environment.ContentRootPath, folderName);

    if (!Directory.Exists(folderPath))
    {
        Directory.CreateDirectory(folderPath);
    }
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
                folderPath),
        RequestPath = "/" + folderName
    }); app.UseStaticFiles();
}

//APLICANDO POLITICA CORS
app.UseCors("CorsPolicy");

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notificationHub");

app.Run();

