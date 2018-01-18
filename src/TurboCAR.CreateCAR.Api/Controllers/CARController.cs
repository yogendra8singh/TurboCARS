using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading.Tasks;
using TurboCAR.CreateCAR.Api.Results;
using TurboCAR.CreateCAR.ApiModel;
using TurboCAR.CreateCAR.Model;
using TurboCAR.CreateCAR.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TurboCAR.CreateCAR.Api.Controllers
{
    [Route("api/[controller]")]
    public class CARController : BaseController
    {
        private string EditCARStatus = "Edit CAR";
        private ICARRepository repository;

        public CARController(ICARRepository _repository)
        {
            repository = _repository;
        }
        
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CARApiModel model)
        {
            string createdCARId = string.Empty;
            if (model == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                var newCAR = new CreditActionRequest()
                {
                    Borrower = model.BorrowerName,
                    CIF = model.CIF,
                    CARType = model.CarType,
                    ActivityStatus = EditCARStatus,
                    CreationDate = DateTime.Now,
                    Status = CARStatus.New
                };
                var createdCAR = await repository.CreateAsync(newCAR);
                createdCARId = createdCAR.CARID;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(string.Format(CultureInfo.InvariantCulture,
                    "{0} : {1}", ex.ParamName, ex.Message));
            }
            return ObjectResponse(StatusCodes.Status200OK, new CARCreationResult
            {
                //CARId = "0",
                CARId = createdCARId,
                Code = "CAR_SUCCESS",
                Message = "Operation Successful"
            });
        }
    }
}
