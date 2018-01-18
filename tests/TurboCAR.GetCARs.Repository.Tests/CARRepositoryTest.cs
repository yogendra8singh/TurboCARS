using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetCARs.Model;
using Xunit;

namespace TurboCAR.GetCARs.Repository.Tests
{
    public class CARRepositoryTest
    {
        private CARRepository repository = null;
        private CreditActionRequest expectedCAR = null;
        private int expectedCount = 21;
        public CARRepositoryTest()
        {
            repository = new CARRepository();
            expectedCAR = new CreditActionRequest() { CARID = "200598", Borrower = "NEW SVB CLIENT FOR TESTING", CARType = CARTypes.NewLoan, ActivityStatus = "SCO CA Approved", CreationDate = DateTime.Parse("02/16/2016") };
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            var result = repository.GetAsync();
            expectedCount = result.Result.Count;
            int actual = result.Result.Count;
            Assert.True(actual == expectedCount);
        }

        [Fact]
        public async Task GetAsyncWithParameterTest()
        {
            var actual = repository.GetAsync("200598").Result;
            Assert.True(actual.CARID == expectedCAR.CARID && actual.Borrower == expectedCAR.Borrower && actual.CARType == expectedCAR.CARType && actual.ActivityStatus == expectedCAR.ActivityStatus && actual.CreationDate == expectedCAR.CreationDate);
        }
    }
}
