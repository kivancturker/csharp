namespace StockPriceTracker;

public class StockMarketMockApi
{
    private List<StockPrice> _stockPrices;
    private int _lastAccessedStockIndex = 0;

    public StockMarketMockApi(int recordAmount)
    {
        _stockPrices = new List<StockPrice>();
        PopulateData(recordAmount);   
    }

    private void PopulateData(int recordAmount)
    {
        Random rand = new Random();
        for (int i = 0; i < recordAmount; i++)
        {
            decimal randomPrice = (decimal)(rand.NextDouble() * 1000);
            StockPrice stockPrice = new StockPrice(
                DateTime.Now.AddSeconds(2 * (i + 1)), 
                randomPrice
                );
            _stockPrices.Add(stockPrice);
        }
    }

    public void PrintAll()
    {
        foreach (StockPrice stockPrice in _stockPrices)
            Console.WriteLine(stockPrice);
    }

    // Simulates real time data
    public StockPrice? GetLastStockPrice()
    {
        if (_lastAccessedStockIndex == _stockPrices.Count - 1)
            return null;
        StockPrice lastAccessedStock = _stockPrices[_lastAccessedStockIndex];
        _lastAccessedStockIndex++;
        return lastAccessedStock;
    }
}