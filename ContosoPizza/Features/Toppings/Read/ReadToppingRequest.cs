
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Toppings.Read
{
    public class ReadToppingRequest : IRequest<ResultOf<ReadToppingResponse>>
    {
        public int Id { get; set; }
    }
}
