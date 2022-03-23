using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class UpdatePizzaRequest : IRequest<bool>
    {
        [JsonIgnore]
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}
