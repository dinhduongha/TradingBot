namespace TradingBot.Core.Domain
{
    public enum Interval
    {
        Minute = 1,
        ThreeMinutes = 3,
        FiveMinutes = 5,
        QuarterHour = 15,
        HalfHour = 30,
        Hour = 60,
        TwoHours = 120,
        FourHours = 240,
        QuarterDay = 360,
        HalfDay = 720,
        Day = 1440,
        Week = 10080,
        Month = 43200,
    }
}
