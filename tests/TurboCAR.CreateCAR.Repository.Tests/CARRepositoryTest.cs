using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.CreateCAR.Model;
using Xunit;

namespace TurboCAR.CreateCAR.Repository.Tests
{
    public class CARRepositoryTest
    {
        private CARRepository repository = null;
        private CreditActionRequest expectedCAR = null;
        private int expectedCount = 21;
        public CARRepositoryTest()
        {
            repository = new CARRepository();
            expectedCAR = new CreditActionRequest() { Borrower = "NEW SVB CLIENT FOR TESTING", CARType = CARTypes.NewLoan, ActivityStatus = "NewLoan", CreationDate = DateTime.Parse("06/16/2016") };
        }

        [Fact]
        public async Task CreateAsync()
        {
            var actual = repository.CreateAsync(expectedCAR).Result;
            expectedCAR.CARID = actual.CARID;
            Assert.True(actual.CARID == expectedCAR.CARID && actual.Borrower == expectedCAR.Borrower && actual.CARType == expectedCAR.CARType && actual.ActivityStatus == expectedCAR.ActivityStatus && actual.CreationDate == expectedCAR.CreationDate);
        }

       
    }
}
