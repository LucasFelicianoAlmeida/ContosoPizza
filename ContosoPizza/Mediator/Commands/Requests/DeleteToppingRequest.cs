using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class DeleteToppingRequest : IRequest<bool>
    {
        [BindNever]
        public int Id { get; set; }
    }
}
