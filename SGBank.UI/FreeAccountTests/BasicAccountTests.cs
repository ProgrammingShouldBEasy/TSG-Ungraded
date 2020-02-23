using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.models;
using SGBank.models.Interfaces;
using SGBank.models.Responses;

namespace FreeAccountTests
{
    [TestFixture]
    public class BasicAccountTests
    {
        [TestCase("33333","Basic Account",100,AccountType.free, 250, false)]
        [TestCase("3333","Basic Account", 100, AccountType.free, 250, false)]
        [TestCase("3333", "Basic Account", 100, AccountType.basic, 250, true)]
        public void BasicAccountTest(string a, string b, decimal c, AccountType d, decimal e, bool f)
        {
            string accountNumber = a;
            string name = b;
            decimal balance = c;
            AccountType accountType = d;
            decimal amount = e;
            bool expectedResult = f;

            IDeposit deposit = DepositRulesFactory.Create(AccountType.basic);

            Account account = new Account();
            account._name = name;
            account._balance = balance;
            account._number = accountNumber;
            account._Type = accountType;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.success);
        }

        [TestCase("33333","Basic Account",1500,AccountType.basic,-1000,1500,false)]
        [TestCase("33333","Basic Account",10,AccountType.free,-100,-100,false)]
        [TestCase("33333","Basic Account",100,AccountType.basic,100,100,false)]
        [TestCase("33333","Basic Account",150,AccountType.basic,-50,100,true)]
        [TestCase("33333","Basic Account",100,AccountType.basic,-150,-60,true)]
        public void BasicAccountWithdrawRuleTest(string a, string b, decimal c, AccountType d, decimal e, decimal f, bool g)
        {
            string accountNumber = a;
            string name = b;
            decimal balance = c;
            AccountType accountType = d;
            decimal amount = e;
            decimal newBalance = f;
            bool expectedResult = g;

            IWithdraw withdraw = WithdrawRulesFactory.Create(AccountType.basic);

            Account account = new Account();
            account._name = name;
            account._balance = balance;
            account._number = accountNumber;
            account._Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.success);
            if(response.success)
            {
                Assert.AreEqual(newBalance, response.Account._balance);
            }
        }
    }
}
