using RiseWebAssessment.Core.Reports;
using RiseWebAssessment.Model;

namespace RiseWebAssessment.Service.ServiceAbstracts
{
    public interface IReportService
    {
        public ReportX GetCountByLocation(string location);
        public ReportX GetTelNumberCountByLocation(string location);
        public ReportX GetLocations();
        public ReportX GetReportFromCache(string reportId);
    }
}
