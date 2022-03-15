using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class CreateToppingHandler : IRequestHandler<CreateToppingRequest, (bool, int)>
    {
        public Task<(bool, int)> Handle(CreateToppingRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return Task.FromResult((false, 0));
            }

            var topping = new Topping() { Name = request.Name, Price = request.Price };
            ToppingsStorage.Toppings.Add(topping);

            //Last id added
            int id = ToppingsStorage.Toppings.LastOrDefault().Id;

            return Task.FromResult((true, id));
        }
    }
}
