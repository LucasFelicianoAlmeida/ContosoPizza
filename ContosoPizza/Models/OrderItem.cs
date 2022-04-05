namespace ContosoPizza.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int IdPizza { get; set; }
        public int IdOrder { get; set; }
        public Order Order { get; set; }
        public Pizza Pizza { get; set; }
        public ICollection<OrderTopping> Toppings { get; set; }
    }
}
