namespace StockPriceTracker;

public class StockPriceProvider : IObservable<StockPrice>
{
    private StockMarketMockApi _stockMarketMockApi;
    private List<IObserver<StockPrice>> _observers;

    public StockPriceProvider(int recordAmount)
    {
        _stockMarketMockApi = new StockMarketMockApi(recordAmount);
        _observers = new List<IObserver<StockPrice>>();
    }
    
    public IDisposable Subscribe(IObserver<StockPrice> observer)
    {
        _observers.Add(observer);
        return new Unsubscriber(_observers, observer);
    }

    public void StartTrackingStockPrices()
    {
        StockPrice? stockPrice;
        do
        {
            stockPrice = _stockMarketMockApi.GetLastStockPrice();
            NotifyAll(stockPrice);
            Thread.Sleep(1000);
        } while (stockPrice != null);
        SendFinalNotificationToAll();
    }

    private void NotifyAll(StockPrice? stockPrice)
    {
        foreach (var observer in _observers)
        {
            if (stockPrice != null)
                observer.OnNext(stockPrice);
        }
    }

    private void SendFinalNotificationToAll()
    {
        foreach (var observer in _observers)
        {
            observer.OnCompleted();
        }
        _observers.Clear();
    }
}