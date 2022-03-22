using ContosoPizza.Mediator.Commands.Responses;
using MediatR;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class ListToppingRequest : IRequest<List<ListToppingResponse>>
    {
    }
}
