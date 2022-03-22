using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;

namespace ContosoPizza
{
    public class ToppingsStorage
    {
        public static List<Topping> Toppings = new List<Topping>();
        public static int nextId = 1;

        public static void AddTopping(Topping topping)
        {
            topping.Id = nextId++;

            Toppings.Add(topping);
        }

        public static bool DeleteTopping(int id)
        {
            Topping topping = Toppings.FirstOrDefault(x => x.Id == id);

            if (topping == null) return false;

            Toppings.Remove(topping);

            return true;
        }

        public static bool UpdateTopping(Topping topping)
        {

            var index = Toppings.FindIndex(0, x => x.Id == topping.Id);

            Toppings[index] = topping;

            return true;
        }

    }
}
