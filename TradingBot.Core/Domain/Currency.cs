namespace TradingBot.Core.Domain
{
    public class Currency
    {
        public string Name { get; }

        public Currency(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }
    }
}
