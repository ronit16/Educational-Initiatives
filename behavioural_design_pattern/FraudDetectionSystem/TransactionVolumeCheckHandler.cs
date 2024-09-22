// TransactionVolumeCheckHandler.cs
public class TransactionVolumeCheckHandler : FraudHandler
{
    private const decimal Threshold = 10000m;

    protected override bool HandleCheck(Transaction transaction)
    {
        if (transaction.Amount > Threshold)
        {
            transaction.IsFlaggedAsFraud = true;
            transaction.FraudReason = $"High Volume Transaction: {transaction.Amount}";
            Console.WriteLine("Transaction Volume Check Failed.");
            return true;  // Stop further handling.
        }

        Console.WriteLine("Transaction Volume Check Passed.");
        return false;  // Continue to the next handler.
    }
}
