using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.CreateCAR.Api.Controllers;
using TurboCAR.CreateCAR.Api.Results;
using TurboCAR.CreateCAR.ApiModel;
using TurboCAR.CreateCAR.Model;
using TurboCAR.CreateCAR.Repository;
using Xunit;

namespace TurboCAR.CreateCAR.Api.Tests
{
    public class CARControllerTest
    {
        private CARController controller = null;
        private ICARRepository repository = null;
        private CreditActionRequest expectedCAR = null;
        private CARApiModel newCreditActionRequest = null;
        public CARControllerTest()
        {
            repository = Substitute.For<ICARRepository>();
            controller = new CARController(repository);
            expectedCAR = new CreditActionRequest()
            {
                CARID = "200598",
                Borrower = "NEW SVB CLIENT FOR TESTING",
                CARType = CARTypes.NewLoan,
                CreationDate = DateTime.Parse("02/16/2016"),
                ActivityStatus = "SCO CA Approved"
            };
            newCreditActionRequest = new CARApiModel()
            {
                BorrowerName = "NEW SVB CLIENT FOR TESTING",
                CarType = CARTypes.NewLoan,
                CreatedDate = DateTime.Parse("02/16/2016"),
            };
        }

        [Fact]
        public async Task PostAsyncTest()
        {
            repository.CreateAsync(Arg.Any<CreditActionRequest>()).Returns(Task.Run(() => expectedCAR));
            var actual = await controller.Post(newCreditActionRequest) as HttpObjectResponse;
            Assert.True(actual.StatusCode == 200);
        }
    }
}
