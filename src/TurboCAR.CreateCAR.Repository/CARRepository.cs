using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.CreateCAR.Model;
using Newtonsoft.Json;

namespace TurboCAR.CreateCAR.Repository
{
    public class CARRepository : ICARRepository
    {
        public CARRepository()
        {
        }

        public async Task<CreditActionRequest> CreateAsync(CreditActionRequest newCAR)
        {
            if (newCAR != null)
            {
                ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect("localhost");
                IDatabase cache = Connection.GetDatabase();
                newCAR.CARID = (new Random().Next(1, 99999) + 300000).ToString();

                //Get the exiting items, and add the new item to it
                string before = cache.StringGet("TurboCAR.CARList");
                var requestsList = JsonConvert.DeserializeObject<List<CreditActionRequest>>(string.IsNullOrWhiteSpace(before) ? string.Empty : before);
                if (requestsList != null && requestsList.Count > 0)
                {
                    requestsList.Insert(0, newCAR);
                }
                else
                {
                    requestsList = new List<CreditActionRequest>();
                    requestsList.Add(newCAR);
                }
                //set the updated list
                cache.StringSet("TurboCAR.CARList", JsonConvert.SerializeObject(requestsList));

            }
            return newCAR;
        }
    }
}
