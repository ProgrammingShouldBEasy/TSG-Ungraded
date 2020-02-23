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
    public class PremiumAccountTests
    {
        [TestCase("11111", "Premium Account", 100, AccountType.free, 250, false)]
        [TestCase("11111", "Premium Account", 100, AccountType.premium, -100, false)]
        [TestCase("11111", "Premium Account", 100, AccountType.premium, 250, true)]
        public void PremiumAccountTest (string a, string b, decimal c, AccountType d, decimal e, bool f)
        {
            string accountNumber = a;
            string name = b;
            decimal balance = c;
            AccountType accountType = d;
            decimal amount = e;
            bool expectedResult = f;

            IDeposit deposit = DepositRulesFactory.Create(AccountType.premium);

            Account account = new Account();
            account._name = name;
            account._balance = balance;
            account._number = accountNumber;
            account._Type = accountType;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.success);
        }

        [TestCase("11111", "Premium Account", 1500, AccountType.premium, -1000, 500, true)]
        [TestCase("11111", "Premium Account", 10, AccountType.free, -100, -100, false)]
        [TestCase("1111", "Premium Account", 100, AccountType.premium, 100, 100, false)]
        [TestCase("11111", "Premium Account", 150, AccountType.premium, -50, 100, true)]
        [TestCase("11111", "Premium Account", 100, AccountType.premium, -550, -450, true)]
        public void PremiumAccountWithdrawRuleTest(string a, string b, decimal c, AccountType d, decimal e, decimal f, bool g)
        {
            string accountNumber = a;
            string name = b;
            decimal balance = c;
            AccountType accountType = d;
            decimal amount = e;
            decimal newBalance = f;
            bool expectedResult = g;

            IWithdraw withdraw = WithdrawRulesFactory.Create(AccountType.premium);

            Account account = new Account();
            account._name = name;
            account._balance = balance;
            account._number = accountNumber;
            account._Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.success);
            if (response.success)
            {
                Assert.AreEqual(newBalance, response.Account._balance);
            }
        }
    }
}
