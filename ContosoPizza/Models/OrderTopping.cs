namespace ContosoPizza.Models
{
    public class OrderTopping
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public virtual OrderItem OrderItem   { get; set; }
    }
}
