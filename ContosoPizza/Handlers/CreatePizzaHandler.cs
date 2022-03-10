using ContosoPizza.Mediator.Requests;
using ContosoPizza.Mediator.Responses;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class CreatePizzaHandler : IRequestHandler<CreatePizzaRequest, CreatePizzaResponse>
    {
        public Task<CreatePizzaResponse> Handle(CreatePizzaRequest request, CancellationToken cancellationToken)
        {
            var response = new CreatePizzaResponse(request.Name,request.IsGlutenFree);
            return Task.FromResult(response);
        }
    }
}