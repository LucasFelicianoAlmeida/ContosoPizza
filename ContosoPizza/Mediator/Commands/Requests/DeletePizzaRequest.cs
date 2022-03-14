using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class DeletePizzaRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
