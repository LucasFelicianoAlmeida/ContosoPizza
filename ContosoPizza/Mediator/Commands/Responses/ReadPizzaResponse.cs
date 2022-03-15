
namespace ContosoPizza.Mediator.Commands.Responses
{
    public class ReadPizzaResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}
