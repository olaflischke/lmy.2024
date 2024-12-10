using System.Globalization;
using System.Xml.Linq;
using TradingDayDal.Extensions;

namespace TradingDayDal;

public class TradingDay
{
    public TradingDay(XElement tradingDayNode)
    {
        this.Date = DateOnly.Parse(tradingDayNode.Attribute("time")!.Value);

        this.Currencies = tradingDayNode.Elements()
                                        .Select(el => new Currency()
                                        {
                                            Symbol = el.Attribute("currency")!.Value,
                                            EuroRate = Convert.ToDouble(el.Attribute("rate")!.Value, NumberFormatInfo.InvariantInfo)
                                        })
                                        .ToList();
    }

    public DateOnly Date { get; set; }
    public List<Currency> Currencies { get; set; } = new();
}
