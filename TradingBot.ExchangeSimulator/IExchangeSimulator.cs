namespace TradingBot.ExchangeSimulator
{
    public interface IExchangeSimulator : IExchange
    {
        bool IsRunning { get; }

        DateTime From { get; }

        DateTime To { get; }

        void Start();

        void Stop();
    }
}
