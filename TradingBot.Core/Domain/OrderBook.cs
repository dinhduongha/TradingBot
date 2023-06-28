namespace TradingBot.Core.Domain
{
    public class OrderBook
    {
        public IEnumerable<OrderBookRow> Asks { get; set; }

        public IEnumerable<OrderBookRow> Bids { get; set; }

        public OrderBook()
        {
            Asks = new List<OrderBookRow>();
            Bids = new List<OrderBookRow>();
        }

        public OrderBook(IEnumerable<OrderBookRow> asks, IEnumerable<OrderBookRow> bids)
        {
            if (asks == null) throw new ArgumentNullException(nameof(asks));
            if (bids == null) throw new ArgumentNullException(nameof(bids));

            Asks = asks;
            Bids = bids;
        }
    }
}
