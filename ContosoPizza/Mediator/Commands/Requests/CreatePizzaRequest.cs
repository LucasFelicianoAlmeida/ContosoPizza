using MediatR;

namespace ContosoPizza.Mediator.Requests
{
    public class CreatePizzaRequest : IRequest<(bool, int)>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}