using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SistemaGestaoTCC.Application.Commands.CamposDocumento.Create
{
    public class CreateCampoCommand : IRequest<int>
    {
        public string Campo { get; set; }
        public int IdCategoria { get; set; }
    }
}
