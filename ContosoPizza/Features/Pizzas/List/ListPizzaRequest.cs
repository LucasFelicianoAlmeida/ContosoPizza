using MediatR;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Pizzas.List
{
    public class ListPizzaRequest : IRequest<ResultOf<List<ListPizzaResponse>>>
    {

    }
}