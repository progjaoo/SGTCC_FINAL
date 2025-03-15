using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestaoTCC.Core.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarUserTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOriginal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Diretorio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tamanho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Arquivo__3214EC0709DE1BE0", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__3214EC0733CAB5D7", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Curso__3214EC078D300E46", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "char(300)", unicode: false, fixedLength: true, maxLength: 300, nullable: false),
                    Justificativa = table.Column<string>(type: "char(300)", unicode: false, fixedLength: true, maxLength: 300, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aprovado = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Projeto__3214EC074D88572F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampoDocumentoAvaliacaoAluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CampoDoc__3214EC07B4B7809F", x => x.Id);
                    table.ForeignKey(
                        name: "FK__CampoDocu__IdCat__0E6E26BF",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Papel = table.Column<int>(type: "int", nullable: false),
                    IdImagem = table.Column<int>(type: "int", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__3214EC07B2323B37", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Usuario__IdCurso__123EB7A3",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Usuario__IdImage__0C85DE4D",
                        column: x => x.IdImagem,
                        principalTable: "Arquivo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Banca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    DataSeminario = table.Column<DateTime>(type: "datetime", nullable: false),
                    Parecer = table.Column<int>(type: "int", nullable: false),
                    ObservacaoNotaProjeto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ObservacaoAluno = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Recomendacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Banca__3214EC0763BEC98E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Banca__IdProjeto__0B91BA14",
                        column: x => x.IdProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjetoArquivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    IdArquivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjetoA__3214EC07172078B8", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProjetoAr__IdArq__0D7A0286",
                        column: x => x.IdArquivo,
                        principalTable: "Arquivo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ProjetoAr__IdPro__04E4BC85",
                        column: x => x.IdProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjetoAtividade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjetoA__3214EC07CDEDCCA7", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProjetoAt__IdPro__00200768",
                        column: x => x.IdProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjetoEntrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataLimite = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime", nullable: true),
                    Entregue = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjetoE__3214EC07FF2E2C97", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProjetoEn__IdPro__7E37BEF6",
                        column: x => x.IdProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjetoTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjetoT__3214EC071C20B105", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProjetoTa__IdPro__7F2BE32F",
                        column: x => x.IdProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjetoAvaliacaoPublica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    Avaliacao = table.Column<int>(type: "int", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjetoA__3214EC07FCCD1D9C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProjetoAv__IdPro__06CD04F7",
                        column: x => x.IdProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ProjetoAv__IdUsu__05D8E0BE",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjetoComentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjetoC__3214EC077F5E0E05", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProjetoCo__IdPro__03F0984C",
                        column: x => x.IdProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ProjetoCo__IdUsu__02FC7413",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioProjeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    Funcao = table.Column<int>(type: "int", nullable: false),
                    AdicionadoEm = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsuarioP__3214EC07612D62A1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UsuarioPr__IdPro__02084FDA",
                        column: x => x.IdProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__UsuarioPr__IdUsu__01142BA1",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AvaliadorBanca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdBanca = table.Column<int>(type: "int", nullable: false),
                    AdicionadoEm = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Avaliado__3214EC07785E3F3B", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Avaliador__IdBan__08B54D69",
                        column: x => x.IdBanca,
                        principalTable: "Banca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Avaliador__IdUsu__07C12930",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AtividadeComentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdAtividade = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeComentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadeComentario_ProjetoAtividade_IdAtividade",
                        column: x => x.IdAtividade,
                        principalTable: "ProjetoAtividade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AtividadeComentario_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjetoEntregaProjeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEntrega = table.Column<int>(type: "int", nullable: false),
                    IdProjeto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjetoEntregaProjeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjetoEntregaProjeto_Entrega",
                        column: x => x.IdEntrega,
                        principalTable: "ProjetoEntrega",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoEntregaProjeto_Projeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotaDocumentoAluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAvaliadorBanca = table.Column<int>(type: "int", nullable: false),
                    IdCampo = table.Column<int>(type: "int", nullable: false),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaDocu__3214EC07B9C2A327", x => x.Id);
                    table.ForeignKey(
                        name: "FK__NotaDocum__IdAlu__09A971A2",
                        column: x => x.IdAluno,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__NotaDocum__IdAva__0F624AF8",
                        column: x => x.IdAvaliadorBanca,
                        principalTable: "AvaliadorBanca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__NotaDocum__IdCam__10566F31",
                        column: x => x.IdCampo,
                        principalTable: "CampoDocumentoAvaliacaoAluno",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotaFinalAluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAvaliadorBanca = table.Column<int>(type: "int", nullable: false),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFina__3214EC076FF9237A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__NotaFinal__IdAlu__0A9D95DB",
                        column: x => x.IdAluno,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__NotaFinal__IdAva__114A936A",
                        column: x => x.IdAvaliadorBanca,
                        principalTable: "AvaliadorBanca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Arquivo__3214EC0659AF81AD",
                table: "Arquivo",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeComentario_IdAtividade",
                table: "AtividadeComentario",
                column: "IdAtividade");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeComentario_IdUsuario",
                table: "AtividadeComentario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliadorBanca_IdBanca",
                table: "AvaliadorBanca",
                column: "IdBanca");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliadorBanca_IdUsuario",
                table: "AvaliadorBanca",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ__Avaliado__3214EC06E4C2872F",
                table: "AvaliadorBanca",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banca_IdProjeto",
                table: "Banca",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "UQ__Banca__3214EC0688563392",
                table: "Banca",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampoDocumentoAvaliacaoAluno_IdCategoria",
                table: "CampoDocumentoAvaliacaoAluno",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "UQ__CampoDoc__3214EC069D5D5B6D",
                table: "CampoDocumentoAvaliacaoAluno",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Categori__3214EC06C29F907D",
                table: "Categoria",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Curso__3214EC06EA6FFBA6",
                table: "Curso",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaDocumentoAluno_IdAluno",
                table: "NotaDocumentoAluno",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_NotaDocumentoAluno_IdAvaliadorBanca",
                table: "NotaDocumentoAluno",
                column: "IdAvaliadorBanca");

            migrationBuilder.CreateIndex(
                name: "IX_NotaDocumentoAluno_IdCampo",
                table: "NotaDocumentoAluno",
                column: "IdCampo");

            migrationBuilder.CreateIndex(
                name: "UQ__NotaDocu__3214EC069F1F206F",
                table: "NotaDocumentoAluno",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFinalAluno_IdAluno",
                table: "NotaFinalAluno",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFinalAluno_IdAvaliadorBanca",
                table: "NotaFinalAluno",
                column: "IdAvaliadorBanca");

            migrationBuilder.CreateIndex(
                name: "UQ__NotaFina__3214EC066E9C820F",
                table: "NotaFinalAluno",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Projeto__3214EC0668F8D5F0",
                table: "Projeto",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoArquivo_IdArquivo",
                table: "ProjetoArquivo",
                column: "IdArquivo");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoArquivo_IdProjeto",
                table: "ProjetoArquivo",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "UQ__ProjetoA__3214EC06EA6996F7",
                table: "ProjetoArquivo",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoAtividade_IdProjeto",
                table: "ProjetoAtividade",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "UQ__ProjetoA__3214EC0686E8F3F1",
                table: "ProjetoAtividade",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoAvaliacaoPublica_IdProjeto",
                table: "ProjetoAvaliacaoPublica",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoAvaliacaoPublica_IdUsuario",
                table: "ProjetoAvaliacaoPublica",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ__ProjetoA__3214EC061E03045F",
                table: "ProjetoAvaliacaoPublica",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoComentario_IdProjeto",
                table: "ProjetoComentario",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoComentario_IdUsuario",
                table: "ProjetoComentario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ__ProjetoC__3214EC06EC319850",
                table: "ProjetoComentario",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoEntrega_IdProjeto",
                table: "ProjetoEntrega",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "UQ__ProjetoE__3214EC06E0AA35FA",
                table: "ProjetoEntrega",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoEntregaProjeto_IdEntrega",
                table: "ProjetoEntregaProjeto",
                column: "IdEntrega");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoEntregaProjeto_IdProjeto",
                table: "ProjetoEntregaProjeto",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "UQ__ProjetoEntregaProjeto",
                table: "ProjetoEntregaProjeto",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoTag_IdProjeto",
                table: "ProjetoTag",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "UQ__ProjetoT__3214EC06278018D2",
                table: "ProjetoTag",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdCurso",
                table: "Usuario",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdImagem",
                table: "Usuario",
                column: "IdImagem");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuario__3214EC068B29E4A2",
                table: "Usuario",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProjeto_IdProjeto",
                table: "UsuarioProjeto",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProjeto_IdUsuario",
                table: "UsuarioProjeto",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ__UsuarioP__3214EC06E08B28F9",
                table: "UsuarioProjeto",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadeComentario");

            migrationBuilder.DropTable(
                name: "NotaDocumentoAluno");

            migrationBuilder.DropTable(
                name: "NotaFinalAluno");

            migrationBuilder.DropTable(
                name: "ProjetoArquivo");

            migrationBuilder.DropTable(
                name: "ProjetoAvaliacaoPublica");

            migrationBuilder.DropTable(
                name: "ProjetoComentario");

            migrationBuilder.DropTable(
                name: "ProjetoEntregaProjeto");

            migrationBuilder.DropTable(
                name: "ProjetoTag");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "UsuarioProjeto");

            migrationBuilder.DropTable(
                name: "ProjetoAtividade");

            migrationBuilder.DropTable(
                name: "CampoDocumentoAvaliacaoAluno");

            migrationBuilder.DropTable(
                name: "AvaliadorBanca");

            migrationBuilder.DropTable(
                name: "ProjetoEntrega");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Banca");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Arquivo");
        }
    }
}
