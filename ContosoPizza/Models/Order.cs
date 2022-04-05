﻿namespace ContosoPizza.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> Order_Items { get; set; }
    }
}
