using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.CreateCAR.Model;

namespace TurboCAR.CreateCAR.Repository
{
    public interface ICARRepository
    {
        Task<CreditActionRequest> CreateAsync(CreditActionRequest newCAR);

    }
}
