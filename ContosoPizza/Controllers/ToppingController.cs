﻿using ContosoPizza.Mediator.Commands.Requests;
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

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ReadToppingRequest() { Id = id });

            if (response == null)
                return NotFound();

            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateToppingRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            if (!response.Item1)
                return BadRequest();


            return CreatedAtAction(nameof(Create), new { Id = response.Item2 });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteToppingRequest() { Id = id }, cancellationToken);

            if (!response)
                return BadRequest();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateToppingRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;
            var response = await _mediator.Send(request, cancellationToken);

            if (!response)
                return BadRequest();

            return Ok();
        }


    }
}
