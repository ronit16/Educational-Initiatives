using System;

namespace ReportGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Select report format (1 for PDF, 2 for CSV): ");
                    var formatInput = Console.ReadLine();

                    IReportBuilder reportBuilder;
                    if (formatInput == "1")
                    {
                        reportBuilder = new PdfReportBuilder();
                    }
                    else if (formatInput == "2")
                    {
                        reportBuilder = new CsvReportBuilder();
                    }
                    else
                    {
                        throw new ArgumentException("Invalid format selected. Please enter 1 for PDF or 2 for CSV.");
                    }

                    // Validate content input
                    string content = "";
                    while (string.IsNullOrWhiteSpace(content))
                    {
                        Console.WriteLine("Enter report content: ");
                        content = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(content))
                        {
                            Console.WriteLine("Error: Content cannot be empty. Please enter valid content.");
                        }
                    }

                    // Validate layout input against allowed values
                    string layout = "";
                    while (!IsValidLayout(layout))
                    {
                        Console.WriteLine("Enter report layout (Single-Page, Paginated): ");
                        layout = Console.ReadLine();
                        if (!IsValidLayout(layout))
                        {
                            Console.WriteLine("Error: Invalid layout. Please enter either 'Single-Page' or 'Paginated'.");
                        }
                    }

                    // Create Director and Construct the Report
                    var director = new ReportDirector(reportBuilder);
                    director.ConstructReport(layout, content, formatInput == "1" ? "PDF" : "CSV");

                    // Get the final report
                    var report = director.GetReport();
                    report.ShowReport();

                    Console.WriteLine("Report generated successfully.");

                    // Prompt to generate another report
                    Console.WriteLine("Do you want to generate another report? (yes/no)");
                    string response = Console.ReadLine()?.ToLower()?.Trim();

                    if (response != "yes") break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        // Method to validate layout input
        public static bool IsValidLayout(string layout)
        {
            return layout == "Single-Page" || layout == "Paginated";
        }
    }
}
