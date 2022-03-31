
using MediatR;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Toppings.List
{
    public class ListToppingRequest : IRequest<ResultOf<List<ListToppingResponse>>>
    {
        public int PageNumber { get; set; }
        public int Quantity { get; set; }
        public string FilterByName { get; set; }
        public decimal? MaximumPrice { get; set; }
        public decimal? MinimunPrice { get; set; }
    }
}
