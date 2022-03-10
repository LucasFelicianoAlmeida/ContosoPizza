using ContosoPizza.Mediator.Requests;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class CreatePizzaHandler : IRequestHandler<CreatePizzaRequest, (bool,int)>
    {
        public Task<(bool,int)> Handle(CreatePizzaRequest request, CancellationToken cancellationToken)
        {

            int id = PizzaStorage.AddPizza(request.Name, request.IsGlutenFree);

            return Task.FromResult((true,id));
        }
    }
}