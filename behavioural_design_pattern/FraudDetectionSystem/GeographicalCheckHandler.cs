// GeographicalCheckHandler.cs
public class GeographicalCheckHandler : FraudHandler
{
    private readonly List<string> _flaggedLocations = new List<string> { "north korea", "iran", "syria" };

    protected override bool HandleCheck(Transaction transaction)
    {
        try
        {
            // Simulate transient error (e.g., external service failure)
            if (new Random().Next(1, 10) > 8)  // 20% chance of failure
            {
                throw new Exception("Geographical verification service failed.");
            }

            if (_flaggedLocations.Contains(transaction.Location.ToLower()))
            {
                transaction.IsFlaggedAsFraud = true;
                transaction.FraudReason = $"Suspicious Location: {transaction.Location}";
                Console.WriteLine("Geographical Check Failed.");
                return true;  // Stop further handling
            }

            Console.WriteLine("Geographical Check Passed.");
            return false;  // Continue to the next handler
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GeographicalCheckHandler: {ex.Message}");
            throw;
        }
    }
}
