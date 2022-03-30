using ContosoPizza.Features.Toppings.Add;
using ContosoPizza.Features.Toppings.Delete;
using ContosoPizza.Features.Toppings.List;
using ContosoPizza.Features.Toppings.Read;
using ContosoPizza.Features.Toppings.Update;
using ContosoPizza.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Toppings
{
    [ApiController]
    [Route("[controller]")]
    public class ToppingController : ControllerBase
    {
        IMediator _mediator;
        public ToppingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Topping>>> GetAll([FromQuery] ListToppingRequest request, CancellationToken cancellationToken) => Ok(await _mediator.Send(request, cancellationToken));

        [HttpGet("{Id}")]
        public Task<ResultOf<ReadToppingResponse>> Get([FromRoute] ReadToppingRequest request, CancellationToken cancellationToken) => _mediator.Send(request, cancellationToken);



        [HttpPost]
        public Task<Result> Create([FromBody] CreateToppingRequest request, CancellationToken cancellationToken) => _mediator.Send(request, cancellationToken);


        [HttpDelete("{id}")]
        public Task<Result> Delete([FromRoute] int id, CancellationToken cancellationToken) => _mediator.Send(new DeleteToppingRequest() { Id = id }, cancellationToken);


        [HttpPut("{id}")]
        public Task<Result> Update(int id, [FromBody] UpdateToppingRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;
            return _mediator.Send(request, cancellationToken);
        }





    }
}
