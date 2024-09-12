using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.ViewModels.CampoDocVM
{
    public class CampoDocumentoViewModel 
    {
        public CampoDocumentoViewModel(int id, string campo, int idCategoria)
        {
            Id = id;
            Campo = campo;
            IdCategoria = idCategoria;
        }
        public int Id { get; set; }
        public string Campo { get; set; }
        public int IdCategoria { get; set; }
    }
}
