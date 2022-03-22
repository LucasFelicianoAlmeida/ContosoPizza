using ContosoPizza.Mediator.Commands.Requests;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class DeleteToppingHandler : IRequestHandler<DeleteToppingRequest, bool>
    {
        public Task<bool> Handle(DeleteToppingRequest request, CancellationToken cancellationToken)
        {
            var result = ToppingsStorage.DeleteTopping(request.Id);

            if (!result) return Task.FromResult(result);

            return Task.FromResult(result);
        }
    }
}
