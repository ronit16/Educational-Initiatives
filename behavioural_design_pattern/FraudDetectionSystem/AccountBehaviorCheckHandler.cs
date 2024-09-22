// AccountBehaviorCheckHandler.cs
public class AccountBehaviorCheckHandler : FraudHandler
{
    private readonly List<string> _suspiciousAccounts = new List<string> { "user123", "user456" };

    protected override bool HandleCheck(Transaction transaction)
    {
        if (_suspiciousAccounts.Contains(transaction.AccountNumber.ToLower()))
        {
            transaction.IsFlaggedAsFraud = true;
            transaction.FraudReason = $"Suspicious Account Activity: {transaction.AccountNumber}";
            Console.WriteLine("Account Behavior Check Failed.");
            return true;  // Stop further handling.
        }

        Console.WriteLine("Account Behavior Check Passed.");
        return false;  // Continue to the next handler.
    }
}
