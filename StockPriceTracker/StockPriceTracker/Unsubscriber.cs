namespace StockPriceTracker;

public class Unsubscriber : IDisposable
{
    private List<IObserver<StockPrice>> _observers;
    private IObserver<StockPrice> _observerToRemove;

    public Unsubscriber(List<IObserver<StockPrice>> observers, IObserver<StockPrice> observerToRemove)
    {
        _observers = observers;
        _observerToRemove = observerToRemove;
    }
    
    public void Dispose()
    {
        if (_observers.Contains(_observerToRemove))
            _observers.Remove(_observerToRemove);
    }
}