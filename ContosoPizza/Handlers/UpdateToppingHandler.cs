using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class UpdateToppingHandler : IRequestHandler<UpdateToppingRequest, bool>
    {
        public Task<bool> Handle(UpdateToppingRequest request, CancellationToken cancellationToken)
        {
            var topping = ToppingsStorage.Toppings.FirstOrDefault(x => x.Id == request.Id);

            if(topping == null) return Task.FromResult(false);

            topping.Name = request.Name;
            topping.Price = request.Price;

            var response = ToppingsStorage.UpdateTopping(topping);

            return Task.FromResult(response);
        }
    }
}
