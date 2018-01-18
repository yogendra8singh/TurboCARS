using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetCARs.Abstraction.ApiModel;
using TurboCAR.GetCARs.Api.Controllers;
using TurboCAR.GetCARs.Model;
using TurboCAR.GetCARs.Repository;
using Xunit;

namespace TurboCAR.GetCARs.Api.Tests
{
    public class CARControllerTest
    {
        private CARController controller = null;
        private ICARRepository repository = null;
        private CreditActionRequest expectedCAR = null;
        private List<CARApiModel> creditActionRequests = null;
        private List<CreditActionRequest> repoOutput = null;
        public CARControllerTest()
        {
            repository = Substitute.For<ICARRepository>();
            controller = new CARController(repository);
            expectedCAR = new CreditActionRequest() {
                CARID= "200598",
                Borrower= "NEW SVB CLIENT FOR TESTING",
                CARType= CARTypes.NewLoan,
                CreationDate = DateTime.Parse("02/16/2016"),
                ActivityStatus = "SCO CA Approved"
            };
            creditActionRequests = JsonConvert.DeserializeObject<List<CARApiModel>>("[{\"Id\":\"200772\",\"Borrower\":\"1320 Entact GP, LP\",\"CARType\":\"BusinessRisk\",\"TeamName\":null,\"Status\":\"New\",\"CreationDate\":\"07/19/2016\",\"Activity\":\"Edit Data\"},{\"Id\":\"200687\",\"Borrower\":\"1320 Excalibur, LP\",\"CARType\":\"CorrectionCar\",\"TeamName\":null,\"Status\":\"New\",\"CreationDate\":\"04/25/2016\",\"Activity\":\"Edit CAR\"},{\"Id\":\"200686\",\"Borrower\":\"CADIENT GROUP INC\",\"CARType\":\"NewLoan\",\"TeamName\":null,\"Status\":\"New\",\"CreationDate\":\"04/24/2016\",\"Activity\":\"Edit CAR\"},{\"Id\":\"200685\",\"Borrower\":\"CADIENT GROUP INC\",\"CARType\":\"NewLoan\",\"TeamName\":null,\"Status\":\"New\",\"CreationDate\":\"04/24/2016\",\"Activity\":\"Edit CAR\"}]");
            repoOutput = JsonConvert.DeserializeObject<List<CreditActionRequest>>("[{\"CIF\":null,\"Borrower\":\"1320 Entact GP, LP\",\"CARType\":2,\"Team\":null,\"CARID\":\"200772\",\"CreationDate\":\"2016-07-19T00:00:00\",\"ActivityStatus\":\"Edit Data\"},{\"CIF\":null,\"Borrower\":\"1320 Excalibur, LP\",\"CARType\":3,\"Team\":null,\"CARID\":\"200687\",\"CreationDate\":\"2016-04-25T00:00:00\",\"ActivityStatus\":\"Edit CAR\"},{\"CIF\":null,\"Borrower\":\"CADIENT GROUP INC\",\"CARType\":1,\"Team\":null,\"CARID\":\"200686\",\"CreationDate\":\"2016-04-24T00:00:00\",\"ActivityStatus\":\"Edit CAR\"},{\"CIF\":null,\"Borrower\":\"CADIENT GROUP INC\",\"CARType\":1,\"Team\":null,\"CARID\":\"200685\",\"CreationDate\":\"2016-04-24T00:00:00\",\"ActivityStatus\":\"Edit CAR\"}]");
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            repository.GetAsync().Returns(Task.Run(() => repoOutput));
            var result = controller.Get();
            int actual = result.Result.Count;
            string dummy = JsonConvert.SerializeObject(result.Result);
            Assert.True(actual == creditActionRequests.Count);
        }

        [Fact]
        public async Task GetAsyncWithParameterTest()
        {
            repository.GetAsync(Arg.Any<string>()).Returns(Task.Run(() => expectedCAR));
            var actual = repository.GetAsync("200598").Result;
            Assert.True(actual.CARID == expectedCAR.CARID && actual.Borrower == expectedCAR.Borrower && actual.ActivityStatus == expectedCAR.ActivityStatus && actual.CARType == expectedCAR.CARType && actual.CreationDate == expectedCAR.CreationDate);
        }
    }
}
