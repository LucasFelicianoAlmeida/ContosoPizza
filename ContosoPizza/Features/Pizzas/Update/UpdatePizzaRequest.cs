using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Core;
using System.Text.Json.Serialization;

namespace ContosoPizza.Features.Pizzas.Update
{
    public class UpdatePizzaRequest : IRequest<Result>
    {
        [JsonIgnore]
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}
