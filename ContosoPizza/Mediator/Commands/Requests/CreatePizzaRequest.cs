using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Core;
using System.Text.Json.Serialization;

namespace ContosoPizza.Mediator.Requests
{
    public class CreatePizzaRequest : IRequest<ResultOf<bool>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}