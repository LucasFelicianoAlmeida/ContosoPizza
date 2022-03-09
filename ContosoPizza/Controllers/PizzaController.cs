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
            var pizzaResponse = await _mediator.Send(new ReadPizzaRequest() { Id= id});
            
            if (pizzaResponse == null)
                return NotFound();

            return Ok(pizzaResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePizzaRequest pizzaRequest)
        {
            var result = await _mediator.Send(pizzaRequest);
            var pizza = PizzaStorage.AddPizza(result.Name, result.IsGlutenFree);

            return CreatedAtAction(nameof(Create), new { id = pizzaRequest.Id }, pizza);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpdatePizzaRequest  pizza)
        {
            
            if (id != pizza.Id)
                return BadRequest();
            var response = await _mediator.Send(new UpdatePizzaRequest() {Id = id });
            if (!response )
                return NotFound();


            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _mediator.Send(new DeletePizzaRequest() {Id=id });
            if (!response)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
