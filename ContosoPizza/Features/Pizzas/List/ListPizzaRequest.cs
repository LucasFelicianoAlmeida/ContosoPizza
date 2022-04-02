using MediatR;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Pizzas.List
{
    public class ListPizzaRequest : PageRequest, IRequest<ResultOf<List<ListPizzaResponse>>>
    {
        public int? MaximumPrice { get; set; }
        public int? MinimumPrice { get; set; }
        public string FilterByName { get; set; }
        public bool? IsGlutenFreeFilter { get; set; }
    }

}