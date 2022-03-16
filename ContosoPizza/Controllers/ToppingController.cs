using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id, CancellationToken cancellationToken)
        {
                var response = await _mediator.Send(new ReadToppingRequest() { Id = id });

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateToppingRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            if (!response)
            {
                return BadRequest();
            }

            int id = ToppingsStorage.Toppings.LastOrDefault().Id;

            return CreatedAtAction(nameof(Create), new { Id = id});
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteToppingRequest() { Id = id }, cancellationToken);
            if (!response)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateToppingRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            if (!response)
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}
