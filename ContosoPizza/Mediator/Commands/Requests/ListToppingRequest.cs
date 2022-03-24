using ContosoPizza.Mediator.Commands.Responses;
using MediatR;
using Nudes.Retornator.Core;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class ListToppingRequest : IRequest<ResultOf<List<ListToppingResponse>>>
    {
    }
}
