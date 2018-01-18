using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TurboCAR.GetCARs.Repository;
using TurboCAR.GetCARs.Model;
using TurboCAR.GetCARs.Abstraction.ApiModel;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TurboCAR.GetCARs.Api.Controllers
{
    [Route("api/[controller]")]
    

    public class CARController : Controller
    {
        private ICARRepository repository;

        public CARController(ICARRepository _repository)
        {
            repository = _repository;
        }
        // GET: api/values
        [HttpGet]
        
        public async Task<List<CARApiModel>> Get()
        {
            
            var CARList =  await repository.GetAsync();

            var returnList = CARList?.Select(x => new CARApiModel() {
                Id = x.CARID,
                Borrower = x.Borrower,
                CARType = x.CARType.ToString(),
                CreationDate = x.CreationDate.ToString("MM/dd/yyyy"),
                TeamName = x.Team?.Name,
                Status = CARStatus.New.ToString(),
                Activity =x.ActivityStatus
            })?.ToList();


            return returnList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<CreditActionRequest> Get(string id)
        {
            return await repository.GetAsync(id);
        }

    }
}
