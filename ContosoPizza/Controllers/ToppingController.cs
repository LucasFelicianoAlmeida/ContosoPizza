using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using ContosoPizza.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nudes.Retornator.Core;

namespace ContosoPizza.Controllers
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
        public async Task<ActionResult<List<Topping>>> GetAll(CancellationToken cancellationToken) => Ok(await _mediator.Send(new ListToppingRequest(), cancellationToken));

        [HttpGet("{Id}")]
        public  Task<ResultOf<ReadToppingResponse>> Get([FromRoute] ReadToppingRequest request, CancellationToken cancellationToken) =>   _mediator.Send(request,cancellationToken);



        [HttpPost]
        public  Task<ResultOf<bool>> Create([FromBody] CreateToppingRequest request, CancellationToken cancellationToken) => _mediator.Send(request, cancellationToken);


        [HttpDelete("{id}")]
        public  Task<Result> Delete([FromRoute] int id, CancellationToken cancellationToken) => _mediator.Send(new DeleteToppingRequest() { Id = id }, cancellationToken);


        [HttpPut("{id}")]
        public  Task<Result> Update(int id, [FromBody] UpdateToppingRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;
            return _mediator.Send(request, cancellationToken);
        }
            

      


    }
}
