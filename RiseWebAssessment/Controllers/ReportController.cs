using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiseWebAssessment.Core.Reports;
using RiseWebAssessment.Model;
using RiseWebAssessment.Service.ServiceAbstracts;

namespace RiseWebAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet("GetLocations")]
        public async Task<ActionResult<ReportX>> GetLocations()
        {
            var report = reportService.GetLocations();
            return Ok(report);
        }
        [HttpGet("GetCountByLocation/{location}")]
        public async Task<ActionResult<ReportX>> GetCountByLocation(string location)
        {
            var report = reportService.GetCountByLocation(location);
            return Ok(report);
        }
        [HttpGet("GetTelNumberCountByLocation/{location}")]
        public async Task<ActionResult<ReportX>> GetTelNumberCountByLocation(string location)
        {
            var report = reportService.GetTelNumberCountByLocation(location);
            return Ok(report);
        }
    }
}
