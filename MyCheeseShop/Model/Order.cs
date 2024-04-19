namespace MyCheeseShop.Model
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal PriceTotal { get; set; }
        public decimal Total { get; set; }
    }
    
}
