namespace ContosoPizza.Models
{
    public class Pizza
    {
        public Pizza()
        {

        }

        public Pizza( string name, decimal price, bool isGlutenFree)
        {
            Name = name;
            Price = price;
            IsGlutenFree = isGlutenFree;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}