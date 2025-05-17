using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.ViewModels.UsersVM
{
    public class UsersAndFunctionViewModel
    {
        public UsersAndFunctionViewModel(int? idUsuario, string? nome, string email, PapelEnum papel, FuncaoEnum funcao, ConviteEnum estado, Arquivo? imagem = null, string? nomeProjeto = null, int id = 0)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Papel = papel;
            Funcao = funcao;
            Estado = estado;
            NomeProjeto = nomeProjeto;

            if (imagem != null)
            {
                Imagem = new ArquivoViewModel(
                    imagem.Id,
                    imagem.NomeOriginal,
                    imagem.Diretorio,
                    imagem.Tamanho,
                    imagem.Extensao,
                    imagem.Id,
                    imagem.CriadoEm,
                    imagem.EditadoEm
                );
            }
            if (imagem != null)
            {
                Imagem = new ArquivoViewModel(
                    imagem.Id,
                    imagem.NomeOriginal,
                    imagem.Diretorio,
                    imagem.Tamanho,
                    imagem.Extensao,
                    imagem.Id,
                    imagem.CriadoEm,
                    imagem.EditadoEm
                );
            }

            Id = id;
        }
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string Email { get; set; }
        public PapelEnum Papel { get; set; }
        public FuncaoEnum Funcao { get; set; }
        public ConviteEnum Estado { get; set; }
        public ArquivoViewModel? Imagem {get; set;}
        public string NomeProjeto { get; set; }
    }
}
