using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/notaDocumentoAluno")]
    [ApiController]
    public class NotaDocumentoAlunoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotaDocumentoAlunoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}