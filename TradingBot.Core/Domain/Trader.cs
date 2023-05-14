namespace TradingBot.Core.Domain
{
    public class Trader : ITrader
    {
        public IAssets Assets { get; }

        public IWallets Wallets { get; }

        public Trader(IWallets wallets)
        {
            if (wallets == null || wallets.Count == 0) throw new ArgumentNullException(nameof(wallets));

            Assets = new Assets();
            Wallets = wallets;
        }
    }
}
