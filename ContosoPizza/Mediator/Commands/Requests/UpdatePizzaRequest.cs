using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class UpdatePizzaRequest : IRequest<bool>
    {
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}
