using ContosoPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPizza
{
    public static class PizzaStore
    {
        public static List<Pizza> Pizzas = new List<Pizza>() { new Pizza() {Name = "Calabresa", IsGlutenFree  = false }, new Pizza {Name = "Mussarela",IsGlutenFree = true } };
    }
}
