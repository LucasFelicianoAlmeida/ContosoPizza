using ContosoPizza.Mediator.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class ReadPizzaRequest : IRequest<ReadPizzaResponse>
    {
        [BindNever]
        public int Id { get; set; }

    }
}
