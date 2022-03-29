
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Pizzas.Read
{
    public class ReadPizzaRequest : IRequest<ResultOf<ReadPizzaResponse>>
    {
        public int Id { get; set; }
    }
}
