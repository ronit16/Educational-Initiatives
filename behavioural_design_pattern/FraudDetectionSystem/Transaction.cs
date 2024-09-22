// Transaction.cs
public class Transaction
{
    public decimal Amount { get; private set; }
    public string Location { get; private set; }
    public string AccountNumber { get; private set; }
    public bool IsFlaggedAsFraud { get; set; } = false;
    public string FraudReason { get; set; } = "None";

    public Transaction(decimal amount, string location, string accountNumber)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than 0.");
        }

        if (string.IsNullOrWhiteSpace(location))
        {
            throw new ArgumentException("Location cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(accountNumber))
        {
            throw new ArgumentException("Account number cannot be empty.");
        }

        Amount = amount;
        Location = location;
        AccountNumber = accountNumber;
    }

    public override string ToString()
    {
        return $"Transaction [Amount: {Amount}, Location: {Location}, Account: {AccountNumber}, IsFraud: {IsFlaggedAsFraud}, Reason: {FraudReason}]";
    }
}
