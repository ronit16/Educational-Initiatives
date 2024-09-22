public class Report
{
    public string Layout { get; set; } = string.Empty;  
    public string Content { get; set; } = string.Empty;  
    public string Format { get; set; } = string.Empty;   

    public void ShowReport()
    {
        Console.WriteLine($"Report Format: {Format}");
        Console.WriteLine($"Layout: {Layout}");
        Console.WriteLine($"Content: {Content}");
    }
}
