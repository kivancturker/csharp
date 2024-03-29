namespace StockPriceTracker;

class Program
{
    static void Main(string[] args)
    {
        StockPriceProvider stockPriceProvider = new StockPriceProvider(5);
        StockPriceDisplay stockPriceDisplay = new();
        EmotionalStockDisplay emotionalStockDisplay = new();
        
        stockPriceDisplay.Subscribe(stockPriceProvider);
        emotionalStockDisplay.Subscribe(stockPriceProvider);
        
        stockPriceProvider.StartTrackingStockPrices();
    }
}