using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Context;
using ContosoPizza.Features.Pizzas.Delete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;

namespace ContosoPizza.Features.Pizzas.Delete
{
    public class DeletePizzaHandler : IRequestHandler<DeletePizzaRequest, Result>
    {
        public ApplicationDbContext _context;
        public DeletePizzaHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Result> Handle(DeletePizzaRequest request, CancellationToken cancellationToken)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);

            if (pizza == null)
                return new NotFoundError();

            _context.Pizzas.Remove(pizza);

            await _context.SaveChangesAsync(cancellationToken);


            return Result.Success;
        }
    }
}
