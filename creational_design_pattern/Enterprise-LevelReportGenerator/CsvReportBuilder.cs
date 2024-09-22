namespace ReportGenerator
{
    public class CsvReportBuilder : IReportBuilder
    {
        private Report _report = new Report();

        public void SetLayout(string layout)
        {
            _report.Layout = layout;
            Console.WriteLine($"Setting layout for CSV: {layout}");
        }

        public void SetContent(string content)
        {
            _report.Content = content;
            Console.WriteLine("Adding content to CSV report.");
        }

        public void SetFormat(string format)
        {
            _report.Format = format;
            Console.WriteLine("Setting format to CSV.");
        }

        public Report GetReport()
        {
            return _report;
        }
    }
}
