using ContosoPizza.Models;
using ContosoPizza.Mediator.Responses;
using MediatR;

namespace ContosoPizza.Mediator.Requests
{
    public class ListPizzaRequest : IRequest<List<ListPizzaResponse>>
    {
       
    }
}