using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;

namespace ContosoPizza
{
    public class ToppingsStorage
    {
        public static List<Topping> Toppings = new List<Topping>() { new Topping {Name = "Sausage",Price = 20 }, new Topping {Name = "Pepperoni", Price = 15 } };

        public static bool DeleteTopping(int id)
        {
            Topping topping = Toppings.FirstOrDefault(x => x.Id == id);

            if(topping == null) return false;

            Toppings.Remove(topping);

            return true;
        }

        public static bool UpdateTopping( UpdateToppingRequest request)
        {
            var topping = Toppings.FirstOrDefault(x => x.Id == request.Id);

            if (topping == null) return false;
            var index = Toppings.IndexOf(topping);

            var toppingUpdated = new Topping() { Id = request.Id, Name = request.Name, Price = request.Price };

            Toppings[index] = toppingUpdated;

            return true;
        }

    }
}
