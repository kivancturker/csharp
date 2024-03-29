namespace StockPriceTracker;

public class EmotionalStockDisplay : IObserver<StockPrice>
{
    private IDisposable? _unsubscriber;
    private Decimal _previousPrice = Decimal.MinValue;
    
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
        Console.WriteLine("Emotional Stock Display is Shutting Down...");
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(StockPrice value)
    {
        ConsoleColor defaultColor = Console.ForegroundColor;
        
        if (_previousPrice == Decimal.MinValue)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Here we go again");
        }

        else if (_previousPrice < value.Price)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"To the Moon. Profit: {value.Price - _previousPrice}");
        }
        else if (_previousPrice == value.Price)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Seems like nothing changed");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"We are crashing. Loss: {_previousPrice - value.Price}");
        }

        _previousPrice = value.Price;
        Console.ForegroundColor = defaultColor;
    }
}