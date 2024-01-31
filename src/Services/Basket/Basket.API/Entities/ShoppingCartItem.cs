namespace Basket.API.Entities
{
    public class ShoppingCartItem
    {
       public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public ShoppingCartItem()
        {
        }
        public ShoppingCartItem(int quantity, string color, decimal unitPrice, string productId, string productName)
        {
            Quantity = quantity;
            Color = color;
            UnitPrice = unitPrice;
            ProductId = productId;
            ProductName = productName;
        }
    }
}