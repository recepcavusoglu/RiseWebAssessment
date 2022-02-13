﻿using RiseWebAssessment.Core.Reports;
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

        public ReportX GetCountByLocation(string location)
        {
            var result = _dataContext.Contacts.Where(x => x.InfoContent == location && x.InfoType == Core.Enums.InfoType.Location)
                                    .GroupBy(content => content.InfoContent)
                                    .Select(group => new BaseReport()
                                    {
                                        Location = group.Select(x => x.InfoContent).Distinct().First(),
                                        Count = group.Count()
                                    }).OrderByDescending(z => z.Count).ToList();
            var reportX = new ReportX();
            reportX.Report = result;
            return reportX;
        }

        public ReportX GetTelNumberCountByLocation(string location)
        {
            var subquery = _dataContext.Contacts.Where(x => x.InfoContent == location && x.InfoType == Core.Enums.InfoType.Location).Select(a => a.UserId).Distinct().ToList();
            var result = _dataContext.Contacts.Where(x => x.InfoType == Core.Enums.InfoType.TelNumber).Where(y => subquery.Contains(y.UserId)).Select(z => z.InfoType).Count();

            var reportX = new ReportX();
            reportX.Report.Add(new BaseReport(location, result));
            return reportX;
        }
        public ReportX GetLocations()
        {
            //string query = "SELECT DISTINCT \"InfoContent\", count(\"InfoContent\") FROM public.\"Contacts\" WHERE \"InfoType\" = 'location' GROUP BY \"InfoContent\"";
            var result = _dataContext.Contacts.Where(x => x.InfoType == Core.Enums.InfoType.Location)
                                    .GroupBy(content => content.InfoContent)
                                    .Select(group => new BaseReport()
                                    {
                                        Location = group.Select(x => x.InfoContent).Distinct().First(),
                                        Count = group.Count()
                                    }).OrderByDescending(z => z.Count).ToList();
            var reportX = new ReportX();
            reportX.Report = result;
            return reportX;
        }
        // TODO: Get Reports from Redis
        public void GetReportFromRedis()
        {

        }
    }
}

