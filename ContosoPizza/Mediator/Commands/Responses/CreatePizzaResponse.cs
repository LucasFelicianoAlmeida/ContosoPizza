using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Mediator.Responses
{
    public class CreatePizzaResponse
    {
        public CreatePizzaResponse()
        {
            //Make a fake identity
            this.Id = nextId++;
        }

        public CreatePizzaResponse(string name, bool isGlutenFree)
        {
            this.Id = nextId++;
            this.Name = name;
            this.IsGlutenFree = isGlutenFree;
        }

        public static int nextId;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}