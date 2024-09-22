namespace ReportGenerator
{
    public class ReportDirector
    {
        private readonly IReportBuilder _reportBuilder;

        public ReportDirector(IReportBuilder reportBuilder)
        {
            _reportBuilder = reportBuilder;
        }

        public void ConstructReport(string layout, string content, string format)
        {
            _reportBuilder.SetLayout(layout);
            _reportBuilder.SetContent(content);
            _reportBuilder.SetFormat(format);
        }

        public Report GetReport()
        {
            return _reportBuilder.GetReport();
        }
    }
}
