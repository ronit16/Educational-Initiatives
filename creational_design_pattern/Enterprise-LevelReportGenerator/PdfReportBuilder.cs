namespace ReportGenerator
{
    public class PdfReportBuilder : IReportBuilder
    {
        private Report _report = new Report();

        public void SetLayout(string layout)
        {
            _report.Layout = layout;
            Console.WriteLine($"Setting layout for PDF: {layout}");
        }

        public void SetContent(string content)
        {
            _report.Content = content;
            Console.WriteLine("Adding content to PDF report.");
        }

        public void SetFormat(string format)
        {
            _report.Format = format;
            Console.WriteLine("Setting format to PDF.");
        }

        public Report GetReport()
        {
            return _report;
        }
    }
}
