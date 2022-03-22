using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Mediator.Commands.Responses;
using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class ListToppingHandler : IRequestHandler<ListToppingRequest, List<ListToppingResponse>>
    {
        public Task<List<ListToppingResponse>> Handle(ListToppingRequest request, CancellationToken cancellationToken)
        {
            var list = ToppingsStorage.Toppings.Select(t => new ListToppingResponse
            {
                Id = t.Id, 
                Name = t.Name,
                Price = t.Price
            }).ToList();

            return Task.FromResult(list);
        }
    }
}
