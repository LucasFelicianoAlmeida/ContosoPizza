using ContosoPizza.Models;
using ContosoPizza.Services;
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
        public ActionResult<List<Pizza>> GetAll()
        {
            return Ok(_mediator.Send(new ListPizzaRequest()));
        }


        //GetById
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> Get(int id)
        {
            var pizzaResponse = await _mediator.Send(new ReadPizzaRequest());
            
            if (pizzaResponse == null)
                return NotFound();

            return Ok(pizzaResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePizzaRequest pizzaRequest)
        {
            var result = await _mediator.Send(pizzaRequest);
            return CreatedAtAction(nameof(Create), new { id = pizzaRequest.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();


            PizzaService.Update(pizza);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _mediator.Send(new DeletePizzaRequest());
            if (!response)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
