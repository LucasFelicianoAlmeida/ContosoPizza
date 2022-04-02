
using MediatR;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Toppings.List
{
    public class ListToppingRequest : PageRequest, IRequest<ResultOf<List<ListToppingResponse>>>
    {
        public string FilterByName { get; set; }
        public decimal? MaximumPrice { get; set; }
        public decimal? MinimunPrice { get; set; }
    }
}
