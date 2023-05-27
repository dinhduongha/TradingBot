namespace TradingBot.Core.Domain
{
    public class Asset : IAsset
    {
        private decimal _price;

        private readonly Instrument _info;
        private readonly Dictionary<decimal, decimal> _lots;

        public decimal Price => _price;

        public decimal Count => _lots.Values.Sum();

        public decimal TotalPrice => Lots.Values.Sum() * _price;

        public decimal AveragePrice => _lots.Sum(lot => lot.Key * lot.Value) / Lots.Values.Sum();

        public Instrument Info => _info;

        public Dictionary<decimal, decimal> Lots => _lots;

        public Asset(Instrument ticker)
        {
            if (ticker == null) throw new ArgumentNullException(nameof(ticker));

            _price = 0;

            _info = ticker;
            _lots = new Dictionary<decimal, decimal>();
        }

        public void Replenish(decimal count, decimal price)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));

            if (!_lots.ContainsKey(price)) _lots.Add(price, count);
            else _lots[price] += count;
        }

        public void Withdraw(decimal count)
        {
            if (count <= 0 || count > Count) throw new ArgumentOutOfRangeException(nameof(count));

            while (count > 0)
            {
                var lot = _lots.OrderBy(lot => lot.Key).First();

                if (lot.Value <= count) _lots.Remove(lot.Key);
                else _lots[lot.Key] -= count;

                count -= lot.Value;
            }
        }

        public void SetPrice(decimal price)
        {
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));

            _price = price;
        }
    }
}
