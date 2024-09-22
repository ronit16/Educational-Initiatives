namespace ReportGenerator
{
    public interface IReportBuilder
    {
        void SetLayout(string layout);
        void SetContent(string content);
        void SetFormat(string format);
        Report GetReport();
    }
}
