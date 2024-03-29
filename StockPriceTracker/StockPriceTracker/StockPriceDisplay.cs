namespace StockPriceTracker;

public class StockPriceDisplay : IObserver<StockPrice>
{
    private IDisposable? _unsubscriber;

    public void Subscribe(IObservable<StockPrice> provider)
    {
        _unsubscriber = provider.Subscribe(this);
    }

    public void Unsubscribe()
    {
        if (_unsubscriber != null)
            _unsubscriber.Dispose();  
    }
    
    public void OnCompleted()
    {
        Console.WriteLine("Stock Price Display Shutting Down...");
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(StockPrice value)
    {
        Console.WriteLine($"Date: {value.RecordTime} | Price: {value.Price}");
    }
}