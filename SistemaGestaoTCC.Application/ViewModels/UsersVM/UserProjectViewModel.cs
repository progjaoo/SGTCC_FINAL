using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.ViewModels.UsersVM
{
    public class UserProjectViewModel
    {
        public UserProjectViewModel(int idUsuario, int idProjeto, FuncaoEnum funcao, Arquivo? imagem = null)
        {
            IdUsuario = idUsuario;
            IdProjeto = idProjeto;
            Funcao = funcao;
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
        }
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public FuncaoEnum Funcao { get; set; }
        public ArquivoViewModel? Imagem { get; set; }
    }
}