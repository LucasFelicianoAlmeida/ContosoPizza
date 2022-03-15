using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class ReadToppingHandler : IRequestHandler<ReadToppingRequest, ReadToppingResponse>
    {
        public Task<ReadToppingResponse> Handle(ReadToppingRequest request, CancellationToken cancellationToken)
        {
            var topping = ToppingsStorage.Toppings.FirstOrDefault(x => x.Id == request.Id);

            if (topping == null) return null;

            var response = new ReadToppingResponse() { Id = topping.Id, Name = topping.Name, Price = topping.Price };

            return Task.FromResult(response);
        }
    }
}
