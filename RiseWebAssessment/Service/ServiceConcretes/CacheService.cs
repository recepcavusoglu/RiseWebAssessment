using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RiseWebAssessment.Core.Reports;
using RiseWebAssessment.Service.ServiceAbstracts;

namespace RiseWebAssessment.Service.ServiceConcretes
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public void SendCache(ReportX report, int expireIn)
        {
            var options = new DistributedCacheEntryOptions(); // create options object
            options.SetSlidingExpiration(TimeSpan.FromMinutes(expireIn)); // expireIn minutes sliding expiration
            distributedCache.SetString(report.ReportId, JsonConvert.SerializeObject(report), options); // set key value pair with options your value will now expire after one minute
        }
        public ReportX GetCache(string reportId)
        {
            var reportX = JsonConvert.DeserializeObject<ReportX>(distributedCache.GetString(reportId));
            return reportX;
        }
    }
}
