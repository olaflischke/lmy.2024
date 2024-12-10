using TradingDayDal;

namespace TradingDalDayUnitTests
{
    [TestClass]
    public sealed class Test1
    {
        string url;

        public Test1()
        {
            url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
        }

        [TestMethod]
        public void IsArchivInitializing()
        {
            // Arrange
            // Act
            Archive archive = new Archive(url);

            TradingDay? day=archive.TradingDays.FirstOrDefault();

            if (day != null)
            {
                Currency? usd = day.Currencies.FirstOrDefault();

                Console.WriteLine($"{day:dd.MM.yy}: {usd.Symbol} - {usd.EuroRate:0.0000}");
            }

            // Assert
            Assert.AreEqual(64, archive.TradingDays.Count);
            
        }

        [TestMethod]
        public void TestMethod2() { }
    }
}
