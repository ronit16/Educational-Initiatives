// FraudHandler.cs
public abstract class FraudHandler
{
    protected FraudHandler NextHandler;
    private const int MaxRetryAttempts = 3;  // Retry up to 3 times in case of transient errors

    public void SetNext(FraudHandler nextHandler)
    {
        NextHandler = nextHandler;
    }

    public void Handle(Transaction transaction)
    {
        try
        {
            if (!HandleCheckWithRetry(transaction) && NextHandler != null)
            {
                NextHandler.Handle(transaction);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in {this.GetType().Name}: {ex.Message}");
            // Log the error in a real application
        }
    }

    // Retry logic for transient errors
    private bool HandleCheckWithRetry(Transaction transaction)
    {
        int attempts = 0;
        while (attempts < MaxRetryAttempts)
        {
            try
            {
                return HandleCheck(transaction);
            }
            catch (Exception ex)
            {
                attempts++;
                if (attempts == MaxRetryAttempts)
                {
                    Console.WriteLine($"Retry attempts failed in {this.GetType().Name}: {ex.Message}");
                    throw;
                }
                Console.WriteLine($"Retrying {this.GetType().Name}, Attempt: {attempts}");
                System.Threading.Thread.Sleep(1000 * attempts); // Exponential backoff
            }
        }
        return false;
    }

    protected abstract bool HandleCheck(Transaction transaction);
}
