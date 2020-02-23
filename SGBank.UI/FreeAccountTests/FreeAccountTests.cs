using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.models.Responses;
using SGBank.models.Interfaces;
using SGBank.models;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;

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

        [TestCase("12345","Free Account",100,AccountType.free,250,false)]
        [TestCase("12345","Free Account",100,AccountType.free,-100,false)]
        [TestCase("12345","Free Account",100,AccountType.basic,50,false)]
        [TestCase("12345","Free Account",100,AccountType.free,50,true)]
        public void FreeAccountDepositRuleTest (string a, string b, decimal c, AccountType d, decimal e, bool f)
        {
            string accountNumber = a;
            string name = b;
            decimal balance = c;
            AccountType accountType = d;
            decimal amount = e;
            bool expectedResult = f;

            IDeposit deposit = DepositRulesFactory.Create(AccountType.free);
            Account account = new Account();
            account._number = accountNumber;
            account._name = name;
            account._balance = balance;
            account._Type = accountType;

            AccountDepositResponse response = new AccountDepositResponse();

            response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.success);
        }

        [TestCase("12345","Free Account",100, AccountType.free,100, false)]
        [TestCase("12345","Free Account",100, AccountType.free,-250, false)]
        [TestCase("12345","Free Account",100, AccountType.basic,-50, false)]
        [TestCase("12345","Free Account",90, AccountType.free,-100, false)]
        [TestCase("12345","Free Account",100, AccountType.free, -10, true)]
        public void FreeAccountWithdrawRuleTest(string a, string b, decimal c, AccountType d, decimal e, bool f)
        {
            string accountNumber = a;
            string name = b;
            decimal balance = c;
            AccountType accountType = d;
            decimal amount = e;
            bool expectedResult = f;

            IWithdraw withdraw = WithdrawRulesFactory.Create(AccountType.free);
            Account account = new Account();
            account._number = accountNumber;
            account._name = name;
            account._balance = balance;
            account._Type = accountType;

            AccountWithdrawResponse response = new AccountWithdrawResponse();

            response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.success);
        }
    }
}
