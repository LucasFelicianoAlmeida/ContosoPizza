
using MediatR;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Toppings.List
{
    public class ListToppingRequest : IRequest<ResultOf<List<ListToppingResponse>>>
    {
    }
}
