using ContosoPizza.Mediator.Commands.Requests;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class UpdateToppingHandler : IRequestHandler<UpdateToppingRequest, bool>
    {
        public Task<bool> Handle(UpdateToppingRequest request, CancellationToken cancellationToken)
        {
            var response = ToppingsStorage.UpdateTopping(request);
            return Task.FromResult(response);
        }
    }
}
