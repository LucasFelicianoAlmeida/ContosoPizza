using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class DeletePizzaRequest : IRequest<bool>
    {
        [BindNever]
        public int Id { get; set; }
    }
}
