using ContosoPizza.Context;
using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using MediatR;

namespace ContosoPizza.Handlers
{
    public class CreateToppingHandler : IRequestHandler<CreateToppingRequest, (bool,int)>
    {
        public ApplicationDbContext _context;
        public CreateToppingHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<(bool,int)> Handle(CreateToppingRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return (false,0);

            var topping = new Topping(request.Name, request.Price);

            _context.Toppings.Add(topping);

            await _context.SaveChangesAsync(cancellationToken);

            return (true,topping.Id);
        }
    }
}
