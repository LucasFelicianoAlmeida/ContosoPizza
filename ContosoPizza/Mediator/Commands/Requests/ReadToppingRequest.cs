using ContosoPizza.Mediator.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class ReadToppingRequest : IRequest<ReadToppingResponse>
    {
        public int Id { get; set; }
    }
}
