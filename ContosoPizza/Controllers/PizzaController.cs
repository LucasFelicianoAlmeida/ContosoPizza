using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ContosoPizza.Mediator.Requests;
using ContosoPizza.Mediator.Commands.Requests;

namespace ContosoPizza.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PizzaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll(CancellationToken cancellationToken) => Ok(_mediator.Send(new ListPizzaRequest(), cancellationToken));


        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> Get(int id, CancellationToken cancellationToken)
        {
            try
            {

                var response = await _mediator.Send(new ReadPizzaRequest() { Id = id }, cancellationToken);
                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePizzaRequest pizzaRequest, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(pizzaRequest, cancellationToken);
            if (!response.Item1)
            {
                return BadRequest();
            }

            //Item2 in tuple in that case is the pizza id returned
            return CreatedAtAction(nameof(Create), new { id = response.Item2 });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePizzaRequest pizza, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new UpdatePizzaRequest() { Id = id }, cancellationToken);

            if (!response)
                return NotFound();


            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(new DeletePizzaRequest() { Id = id }, cancellationToken);
            if (!response)
                return NotFound();

            return Ok();
        }

    }
}
