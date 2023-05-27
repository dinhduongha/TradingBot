namespace TradingBot.Core.Domain
{
    public interface IAsset
    {
        decimal Count { get; }

        decimal Price { get; }

        decimal TotalPrice { get; }

        decimal AveragePrice { get; }

        Instrument Info { get; }

        Dictionary<decimal, decimal> Lots { get; }

        void Replenish(decimal count, decimal price);

        void Withdraw(decimal count);

        void SetPrice(decimal price);
    }
}
