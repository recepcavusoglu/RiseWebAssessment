namespace RiseWebAssessment.Core.Reports
{
    public class BaseReport
    {
        
        public string Location { get; set; }
        public int Count { get; set; }

        public BaseReport(string location, int count)
        {
            this.Location = location;
            this.Count = count;
        }
        public BaseReport() { }
        
    }
}
