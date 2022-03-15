using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class DeleteToppingRequest : IRequest<(bool, int)>
    {
        [BindNever]
        public int Id { get; set; }
    }
}
