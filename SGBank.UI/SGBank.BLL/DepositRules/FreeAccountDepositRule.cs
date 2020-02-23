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
    public class FreeAccountDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();
            if(account._Type != AccountType.free)
            {
                response.success = false;
                response.message = "Error: A non free account hit the Free Deposit Rule. Contact IT";
                return response;
            }

            if(amount  > 100)
            {
                response.success = false;
                response.message = "Free accounts cannot deposit more than $100 at a time";
                return response;
            }

            if(amount  <= 0)
            {
                response.success = false;
                response.message = "Deposit amount must be greater than zero.";
                return response;
            }

            response.OldBalance = account._balance;
            account._balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.success = true;

            return response;
        }
    }
}
