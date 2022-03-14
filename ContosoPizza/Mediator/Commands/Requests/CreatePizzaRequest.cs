using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContosoPizza.Mediator.Requests
{
    public class CreatePizzaRequest : IRequest<(bool, int)>
    {
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}