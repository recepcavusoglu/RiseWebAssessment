using RiseWebAssessment.Core.Reports;
using RiseWebAssessment.Model;

namespace RiseWebAssessment.Service.ServiceAbstracts
{
    public interface IReportService
    {
        public void GetCountByLocation(string location);
        public void GetTelNumberCountByLocation(string location);
        public List<BaseReport> GetLocations();
        public void GetReportFromRedis();
    }
}
