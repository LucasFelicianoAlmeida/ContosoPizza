using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class CreateToppingRequest : IRequest<bool>
    {
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
