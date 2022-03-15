using ContosoPizza.Mediator.Commands.Requests;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class DeleteToppingHandler : IRequestHandler<DeleteToppingRequest, (bool, int)>
    {
        public Task<(bool, int)> Handle(DeleteToppingRequest request, CancellationToken cancellationToken)
        {
            var result = ToppingsStorage.DeleteTopping(request.Id);

            if (!result) return Task.FromResult((result, 0));

            return Task.FromResult((result, request.Id));
        }
    }
}
