using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ContosoPizza.Mediator.Requests;
using ContosoPizza.Mediator.Commands.Requests;
using Nudes.Retornator.Core;
using ContosoPizza.Mediator.Commands.Responses;

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
        public async Task<ActionResult<List<Pizza>>> GetAll(CancellationToken cancellationToken) => Ok(await _mediator.Send(new ListPizzaRequest(), cancellationToken));


        //GetById
        [HttpGet("{Id}")]
        public  Task<ResultOf<ReadPizzaResponse>> Get([FromRoute ] ReadPizzaRequest request, CancellationToken cancellationToken) => _mediator.Send(request, cancellationToken);

        [HttpPost]
        public Task<ResultOf<bool>> Create([FromBody] CreatePizzaRequest pizzaRequest, CancellationToken cancellationToken) => _mediator.Send(pizzaRequest, cancellationToken);


        [HttpPut("{id}")]
        public Task<ResultOf<bool>> Update(int id, [FromBody] UpdatePizzaRequest pizza, CancellationToken cancellationToken)
        {
            pizza.Id = id;
            return _mediator.Send(pizza, cancellationToken);
        }

        [HttpDelete("{Id}")]
        public Task<Result> Delete([FromRoute] DeletePizzaRequest request, CancellationToken cancellationToken) => _mediator.Send(request, cancellationToken);


    }
}
