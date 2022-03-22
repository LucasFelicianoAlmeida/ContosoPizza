﻿using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class CreateToppingHandler : IRequestHandler<CreateToppingRequest, bool>
    {
        public Task<bool > Handle(CreateToppingRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return Task.FromResult(false);
            }
            var topping = new Topping
            {
                Name = request.Name,
                Price = request.Price
            };

            ToppingsStorage.AddTopping(topping);


            return Task.FromResult(true);
        }
    }
}
