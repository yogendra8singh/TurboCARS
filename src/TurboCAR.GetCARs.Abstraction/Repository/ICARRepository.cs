using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetCARs.Model;

namespace TurboCAR.GetCARs.Repository
{
    public interface ICARRepository
    {
        Task<List<CreditActionRequest>> GetAsync();
        Task<CreditActionRequest> GetAsync(string cARId);

    }
}
