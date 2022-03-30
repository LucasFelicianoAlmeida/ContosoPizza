using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Toppings.Delete
{
    public class DeleteToppingRequest : IRequest<Result>
    {
        [BindNever]
        public int Id { get; set; }
    }
}
