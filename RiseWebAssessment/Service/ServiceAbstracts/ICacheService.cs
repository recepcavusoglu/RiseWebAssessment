using RiseWebAssessment.Core.Reports;

namespace RiseWebAssessment.Service.ServiceAbstracts
{
    public interface ICacheService
    {
        public void SendCache(ReportX report,int expireIn);
        public ReportX GetCache(string reportId);
    }
}
