using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Mediator.Responses
{
    public class CreatePizzaResponse 
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public bool IsGlutenFree {get;set;}
    }
}