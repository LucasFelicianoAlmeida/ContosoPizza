using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Core;
using System.Text.Json.Serialization;

namespace ContosoPizza.Features.Pizzas.Add
{
    public class CreatePizzaRequest : IRequest<Result>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}