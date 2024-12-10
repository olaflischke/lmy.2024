
using System.Xml.Linq;

namespace TradingDayDal;

public class Archive
{
    /// <summary>
    /// Initializes a new instance of the Archive class with the specified URL.
    /// </summary>
    /// <param name="url">The URL to fetch trading day data from.</param>
    public Archive(string url)
    {

        this.TradingDays = GetData(url);
    }

    private List<TradingDay> GetData(string url)
    {
        XDocument document = XDocument.Load(url);

        var q = document.Root?.Descendants()
                                .Where(xe => xe.Name.LocalName == "Cube" && xe.Attributes().Any(at => at.Name == "time"))
                                // Projektion
                                .Select(xe => new TradingDay(xe)); // { Date = DateOnly.Parse(xe.Attribute("time")!.Value) });

        return q.ToList();

        //List<TradingDay> days = new List<TradingDay>();

        //foreach (var xe in q)
        //{
        //    TradingDay day = new TradingDay() { Date = DateOnly.Parse(xe.Attribute("time")!.Value) };
        //    days.Add(day);
        //}

        //return days;
    }

    private bool GetXElementByName(XElement xe, string v)
    {
        if (xe.Name.LocalName == "Cube")
        {
            return true;
        }
        return false;

    }

    public List<TradingDay> TradingDays { get; set; }
}
