using ContosoPizza.Mediator.Responses;
using MediatR;
using Nudes.Retornator.Core;

namespace ContosoPizza.Mediator.Requests
{
    public class ListPizzaRequest : IRequest<ResultOf<List<ListPizzaResponse>>>
    {

    }
}