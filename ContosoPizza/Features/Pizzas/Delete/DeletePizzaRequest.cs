using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPizza.Features.Pizzas.Delete
{
    public class DeletePizzaRequest : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
