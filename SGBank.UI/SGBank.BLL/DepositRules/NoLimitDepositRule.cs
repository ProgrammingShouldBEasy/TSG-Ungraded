using SGBank.models;
using SGBank.models.Interfaces;
using SGBank.models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.DepositRules
{
    public class NoLimitDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            if(account._Type != AccountType.basic && account._Type != AccountType.premium)
            {
                response.success = false;
                response.message = "Error: Only basic and premium accounts can deposit with no limit. Contact IT";
                return response;
            }

            if(amount <= 0)
            {
                response.success = false;
                response.message = "Deposit amounts must be positive!";
                return response;
            }

            response.success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account._balance;
            account._balance += amount;
            return response;
        }
    }
}
