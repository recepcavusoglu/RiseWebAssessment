namespace RiseWebAssessment.Core.Reports
{
    public class BaseReport
    {
        public string UUID { get; } = Guid.NewGuid().ToString();
        public string Location { get; set; }
        public int Count { get; set; }
        public DateTime CreationTime { get; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
    }
}
