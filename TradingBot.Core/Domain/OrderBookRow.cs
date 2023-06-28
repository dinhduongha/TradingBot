namespace TradingBot.Core.Domain
{
    public class OrderBookRow
    {
        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public OrderBookRow(decimal price, decimal quantity)
        {
            Price = price;
            Quantity = quantity;
        }

        public OrderBookRow() : this(0, 0)
        {
            
        }
    }
}
