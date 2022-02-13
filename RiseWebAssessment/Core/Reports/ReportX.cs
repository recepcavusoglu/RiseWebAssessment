namespace RiseWebAssessment.Core.Reports
{
    public class ReportX
    {
        public string ReportId { get; } = Guid.NewGuid().ToString();
        public string ReportMessage { get; } = "This report can be accessible with reportId for a while via Redis";
        public List<BaseReport> Report { get; set; } = new List<BaseReport>();
        public DateTime CreationTime { get; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
    }
}
