using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetCARs.Model;
using Newtonsoft.Json;
using Serilog;

namespace TurboCAR.GetCARs.Repository
{
    public class CARRepository : ICARRepository
    {
        public CARRepository()
        {
        }

        public async Task<List<CreditActionRequest>> GetAsync()
        {
            try
            {
                ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect("localhost");
                IDatabase cache = Connection.GetDatabase();
                var returnRequests = JsonConvert.DeserializeObject<List<CreditActionRequest>>(cache.StringGet("TurboCAR.CARList"));
                return returnRequests;
            }
            catch (Exception ex)
            {
                Log.Error<Exception>("Error", ex);
                throw;
            }

           
        }

        public async Task<CreditActionRequest> GetAsync(string cARId)
        {
            var requests = await GetAsync();
            return requests.Find(x => x.CARID == cARId);
        }
    }
}
