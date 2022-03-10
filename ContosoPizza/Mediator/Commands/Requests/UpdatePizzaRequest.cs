using MediatR;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class UpdatePizzaRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}
