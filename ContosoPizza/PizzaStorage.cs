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
        public static List<Pizza> Pizzas = new List<Pizza>() { new Pizza() {Id =1, Name = "Calabresa", IsGlutenFree  = false }, new Pizza {Id = 2 , Name = "Mussarela",IsGlutenFree = true } };
        public static int nextId = Pizzas.Count  + 1 ;

        public static Pizza AddPizza(string name, bool isGlutenFree)
        {
            var pizza = new Pizza() {Name =name,IsGlutenFree = isGlutenFree, Id =nextId++ };
            Pizzas.Add(pizza);
            return pizza;
        }
        public static bool UpdatePizza(UpdatePizzaRequest pizza)
        {
            var pizzaChanged = Pizzas.FirstOrDefault(x => x.Id == pizza.Id);
            if (pizzaChanged == null)
            {
                return false;
            }
            pizzaChanged.Name = pizza.Name;
            pizzaChanged.IsGlutenFree = pizza.IsGlutenFree;
            PizzaStorage.Pizzas.Add(pizzaChanged);
            return true;
            
        }
    }
}
