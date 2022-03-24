using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Core;
using System.Text.Json.Serialization;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class CreateToppingRequest : IRequest<ResultOf<bool>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
