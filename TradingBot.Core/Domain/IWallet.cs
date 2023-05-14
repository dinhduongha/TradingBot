namespace TradingBot.Core.Domain
{
    public interface IWallet
    {
        string Currency { get; }

        decimal Balance { get; }

        void Replenish(decimal balance);

        void Withdraw(decimal balance);
    }
}
