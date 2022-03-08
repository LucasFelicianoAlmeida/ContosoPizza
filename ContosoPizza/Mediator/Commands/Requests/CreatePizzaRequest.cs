
using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Mediator.Requests
{
    public class CreatePizzaRequest : IRequest<Pizza>
    {
        public int Id {get;set;}
        public string Name {get; set;}
        public bool IsGlutenFree {get;set;}
    }
}