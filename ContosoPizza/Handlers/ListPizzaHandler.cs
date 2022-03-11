
using ContosoPizza.Mediator.Requests;
using ContosoPizza.Mediator.Responses;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class ListPizzaHandler : IRequestHandler<ListPizzaRequest, List<ListPizzaResponse>>
    {

        public Task<List<ListPizzaResponse>> Handle(ListPizzaRequest request, CancellationToken cancellationToken)
        {
            var pizzaList = PizzaStorage.Pizzas.Select(p => new ListPizzaResponse
            {
                Id = p.Id,
                IsGlutenFree = p.IsGlutenFree,
                Name = p.Name
            }).ToList();

            return Task.FromResult(pizzaList);
        }
    }
}