namespace TradingBot.Core.Domain
{
    public class Wallet : IWallet
    {
        private readonly string _currency;

        private decimal _balance;

        public string Currency => _currency;

        public decimal Balance => _balance;

        public Wallet(string currency, decimal baseBalance)
        {
            if (string.IsNullOrEmpty(currency)) throw new ArgumentNullException(nameof(currency));
            if (baseBalance < 0) throw new ArgumentOutOfRangeException(nameof(baseBalance));

            _currency = currency;
            _balance = baseBalance;
        }

        public void Replenish(decimal balance)
        {
            if (balance <= 0) throw new ArgumentOutOfRangeException(nameof(balance));

            _balance += balance;
        }

        public void Withdraw(decimal balance)
        {
            if (balance <= 0) throw new ArgumentOutOfRangeException(nameof(balance));

            _balance -= balance;
        }
    }
}
