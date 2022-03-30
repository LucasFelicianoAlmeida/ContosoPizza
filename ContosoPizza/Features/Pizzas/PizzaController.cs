using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Nudes.Retornator.Core;
using ContosoPizza.Features.Pizzas.Add;
using ContosoPizza.Features.Pizzas.Read;
using ContosoPizza.Features.Pizzas.Update;
using ContosoPizza.Features.Pizzas.Delete;
using ContosoPizza.Features.Pizzas.List;

namespace ContosoPizza.Features.Pizzas
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
        public async Task<ActionResult<List<Pizza>>> GetAll(CancellationToken cancellationToken) => Ok(await _mediator.Send(new ListPizzaRequest(), cancellationToken));


        //GetById
        [HttpGet("{Id}")]
        public  Task<ResultOf<ReadPizzaResponse>> Get([FromRoute ] ReadPizzaRequest request, CancellationToken cancellationToken) => _mediator.Send(request, cancellationToken);

        [HttpPost]
        public Task<Result> Create([FromBody] CreatePizzaRequest pizzaRequest, CancellationToken cancellationToken) => _mediator.Send(pizzaRequest, cancellationToken);


        [HttpPut("{id}")]
        public Task<Result> Update(int id, [FromBody] UpdatePizzaRequest pizza, CancellationToken cancellationToken)
        {
            pizza.Id = id;
            return _mediator.Send(pizza, cancellationToken);
        }

        [HttpDelete("{Id}")]
        public Task<Result> Delete([FromRoute] DeletePizzaRequest request, CancellationToken cancellationToken) => _mediator.Send(request, cancellationToken);


    }
}
