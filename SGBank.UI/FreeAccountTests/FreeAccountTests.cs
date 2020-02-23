using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.models.Responses;
using SGBank.models.Interfaces;

namespace FreeAccountTests
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookUpResponse accountResponse = manager.LookupAccount("12345");

            Assert.IsNotNull(accountResponse.Account);
            Assert.IsTrue(accountResponse.success);
            Assert.AreEqual("12345", accountResponse.Account._number);
        }
    }
}
