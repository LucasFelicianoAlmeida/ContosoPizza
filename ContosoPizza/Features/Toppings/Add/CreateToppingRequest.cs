using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Core;
using System.Text.Json.Serialization;

namespace ContosoPizza.Features.Toppings.Add
{
    public class CreateToppingRequest : IRequest<Result>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
