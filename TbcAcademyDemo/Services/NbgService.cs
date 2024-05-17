using Microsoft.Extensions.Caching.Distributed;

namespace TbcAcademyDemo.Services
{
    public class NbgService : INbgService
    {
        private const string BaseUrl = "https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies/ka/json/";
        private readonly IDistributedCache _distributedCache;

        public NbgService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<string> GetRates(CancellationToken cancellationToken)
        {
            string? rates;
            var options = new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30) };

            using var client = new HttpClient();
            rates = await _distributedCache.GetStringAsync("NbgRates", cancellationToken);

            if (string.IsNullOrEmpty(rates))
            {
                rates = await client.GetStringAsync($"{BaseUrl}?date={DateTime.Now.Date}", cancellationToken);
                await _distributedCache.SetStringAsync("NbgRates", rates, options, cancellationToken);
            }

            return rates;
        }
    }
}
