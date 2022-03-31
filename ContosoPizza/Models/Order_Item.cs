namespace ContosoPizza.Models
{
    public class Order_Item
    {
        public int Id { get; set; }
        public int IdPizza { get; set; }
        public int IdOrder { get; set; }
        public Order Order { get; set; }
    }
}
