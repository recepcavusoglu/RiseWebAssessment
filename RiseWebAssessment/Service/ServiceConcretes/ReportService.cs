using RiseWebAssessment.Core.Reports;
using RiseWebAssessment.Model;
using RiseWebAssessment.Service.ServiceAbstracts;
using static RiseWebAssessment.Core.Enums;

namespace RiseWebAssessment.Service.ServiceConcretes
{
    public class ReportService : IReportService
    {
        private readonly DataContext _dataContext;

        public ReportService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void GetCountByLocation(string location)
        {

        }

        public void GetTelNumberCountByLocation(string location)
        {

        }
        // TODO: Sort This Dict
        public List<BaseReport> GetLocations()
        {
            //string query = "SELECT DISTINCT \"InfoContent\", count(\"InfoContent\") FROM public.\"Contacts\" WHERE \"InfoType\" = 'location' GROUP BY \"InfoContent\"";
            var result = _dataContext.Contacts.Where(x => x.InfoType == Core.Enums.InfoType.Location)
                                    .GroupBy(content => content.InfoContent)
                                    .Select(group => new BaseReport()
                                    {
                                        Location = group.Select(x => x.InfoContent).Distinct().First(),
                                        Count = group.Count()
                                    }).OrderByDescending(z => z.Count).ToList();  
            return result;
        }
        public void GetReportFromRedis()
        {
            
        }
    }
}

