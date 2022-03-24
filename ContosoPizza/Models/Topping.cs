namespace ContosoPizza.Models
{
    public class Topping
    {
        
        public Topping()
        {

        }

        public Topping(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

  
    }
}
