using ContosoPizza.Mediator.Commands.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class ReadPizzaRequest : IRequest<ReadPizzaResponse>
    {
        public int Id { get; set; }

    }
}
