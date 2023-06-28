using TradingBot.Core.Converters.Exchange;
using TradingBot.Core.Domain;

namespace TradingBot.Quik.Converters
{
    public class OrderBookConverter : IOrderBookConverter<QuikSharp.DataStructures.OrderBook>
    {
        public OrderBook Convert(QuikSharp.DataStructures.OrderBook input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var asks = input.offer.Select(ask => new OrderBookRow(System.Convert.ToDecimal(ask.price),
                System.Convert.ToDecimal(ask.quantity)));

            var bids = input.bid.Select(bid => new OrderBookRow(System.Convert.ToDecimal(bid.price),
                System.Convert.ToDecimal(bid.quantity)));

            return new OrderBook(asks, bids);
        }
    }
}
