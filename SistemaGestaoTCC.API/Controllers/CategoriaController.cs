using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.Categorias.Create;
using SistemaGestaoTcc.Application.Commands.Categorias.Delete;
using SistemaGestaoTcc.Application.Commands.Categorias.Update;
using SistemaGestaoTcc.Application.Queries.Categorias.GetAll;
using SistemaGestaoTcc.Application.Queries.Categorias.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/categoriasDocumento")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllCategoryQuery = new GetAllCategoriaQuery();

            var categoria = await _mediator.Send(getAllCategoryQuery);

            return Ok(categoria);
        }
        [HttpGet("{id}/buscarPorId")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCategoriaByIdQuery(id);

            var categoria = await _mediator.Send(query);

            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }
        [HttpPost("criarCategoria")]
        public async Task<IActionResult> PostCourse([FromBody] CreateCategoriaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("{id}/atualizarCategoria")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoriaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarCategoria")]
        public async Task<IActionResult> Delete(DeleteCategoriaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}