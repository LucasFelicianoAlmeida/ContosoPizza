namespace ContosoPizza.Models
{
    public class OrderTopping
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public OrderItem OrderItem   { get; set; }
    }
}
