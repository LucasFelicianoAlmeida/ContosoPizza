using MediatR;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Pizzas.List
{
    public class ListPizzaRequest : IRequest<ResultOf<List<ListPizzaResponse>>>
    {
        public int PageNumber { get; set; }
        public int Quantity { get; set; }
        public int? MaximumPrice { get; set; }
        public int? MinimumPrice { get; set; }
        public string FilterByName { get; set; }
        public bool? IsGlutenFreeFilter { get; set; }
    }

}