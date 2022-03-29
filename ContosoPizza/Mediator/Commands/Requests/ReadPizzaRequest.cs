using ContosoPizza.Mediator.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Core;

namespace ContosoPizza.Mediator.Commands.Requests
{
    public class ReadPizzaRequest : IRequest<ResultOf<ReadPizzaResponse>>
    {
        //[BindNever]
        public int Id { get; set; }

    }
}
