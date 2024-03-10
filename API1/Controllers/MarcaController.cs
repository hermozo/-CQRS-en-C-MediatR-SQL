using API.MediatR.Marca.Commands;
using API1.Data.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        public IMediator _mediator { get; set; }
        public MarcaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> actionIndex()
        {
            var model = new GetAllMarcaCommand{};
            var result = await _mediator.Send(model);
            return Ok(result);
        }        

        [HttpGet("{id}")]
        public async Task<IActionResult> actionView(int id)
        {
            var model = new GetByIdQuery(id);
            if (model == null) { 
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> actionCreate(CreateCommand marca)
        {
            var resul = await _mediator.Send(marca);
            return Ok(resul);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> actionUpdate(int id, UpdateCommand marca)
        {
            var tarea = await _mediator.Send(marca);
            if (tarea == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> actionDelete(int id)
        {
            var result = await _mediator.Send(new DeleteCommand(id));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
