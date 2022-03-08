using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ContosoPizza.Mediator.Requests;

namespace ContosoPizza.Controllers;

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
    public ActionResult<List<Pizza>> GetAll() => Ok(_mediator.Send(PizzaService.GetAll()));

    //GetById
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza == null)
            return NotFound();

        return pizza;
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
            //TO STUDY LATER these new action results methods 
            //https://exceptionnotfound.net/asp-net-core-demystified-action-results/
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);
        if(pizza is null)
        return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }





}