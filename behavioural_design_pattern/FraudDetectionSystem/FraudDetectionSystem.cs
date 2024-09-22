// FraudDetectionSystem.cs
public class FraudDetectionSystem
{
    private FraudHandler _chain;

    public FraudDetectionSystem()
    {
        // Build the chain of responsibility
        var geographicalHandler = new GeographicalCheckHandler();
        var volumeHandler = new TransactionVolumeCheckHandler();
        var accountHandler = new AccountBehaviorCheckHandler();

        // Link the handlers
        geographicalHandler.SetNext(volumeHandler);
        volumeHandler.SetNext(accountHandler);

        _chain = geographicalHandler;
    }

    public void Run()
    {
        string userInput;
        do
        {
            Console.WriteLine("\n--- Fraud Detection System ---");
            Console.WriteLine("1. Enter new transaction");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    HandleUserTransaction();
                    break;
                case "2":
                    Console.WriteLine("Exiting the system...");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        } while (userInput != "2");
    }

    private void HandleUserTransaction()
    {
        try
        {
            // Gather inputs
            Console.Write("Enter transaction amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter transaction location: ");
            string location = Console.ReadLine();

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            // Create and process the transaction
            var transaction = new Transaction(amount, location, accountNumber);
            ProcessTransaction(transaction);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input format. Please try again.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Validation error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error occurred: {ex.Message}");
        }
    }

    private void ProcessTransaction(Transaction transaction)
    {
        Console.WriteLine("Processing Transaction...");
        _chain.Handle(transaction);
        Console.WriteLine(transaction.ToString());
    }
}
