namespace Orders_ShoppingApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}
