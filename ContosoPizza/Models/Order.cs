namespace ContosoPizza.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<Order_Item> Order_Items { get; set; }
    }
}
