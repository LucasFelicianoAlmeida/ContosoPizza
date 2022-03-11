using ContosoPizza.Mediator.Commands.Requests;
using ContosoPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPizza
{
    public static class PizzaStorage
    {
        public static List<Pizza> Pizzas = new List<Pizza>() { new Pizza() { Id = 1, Name = "Calabresa", IsGlutenFree = false }, new Pizza { Id = 2, Name = "Mussarela", IsGlutenFree = true } };
        public static int nextId = Pizzas.Count + 1;

        public static int AddPizza(string name, bool isGlutenFree)
        {
            var pizza = new Pizza() { Name = name, IsGlutenFree = isGlutenFree, Id = nextId++ };
            Pizzas.Add(pizza);

            return pizza.Id;
        }
        public static bool UpdatePizza(Pizza p)
        {
            var pizza = Pizzas.FirstOrDefault(x => x.Id == p.Id);
            if (pizza == null)
                return false;
            var index = Pizzas.IndexOf(pizza);

            pizza.Name = pizza.Name;
            pizza.IsGlutenFree = pizza.IsGlutenFree;

            Pizzas[index] = pizza;
            return true;

        }
    }
}
