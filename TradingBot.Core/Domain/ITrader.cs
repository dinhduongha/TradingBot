namespace TradingBot.Core.Domain
{
    public interface ITrader
    {
        IAssets Assets { get; }

        IWallets Wallets { get; }
    }
}
