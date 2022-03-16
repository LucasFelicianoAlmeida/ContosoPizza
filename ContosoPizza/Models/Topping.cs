namespace ContosoPizza.Models
{
    public class Topping
    {
        static int nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

  
    }
}
