using ContosoPizza.Mediator.Commands.Responses;
using MediatR;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class ReadPizzaRequest : IRequest<ReadPizzaResponse>
    {
        public int Id { get; set; }

    }
}
