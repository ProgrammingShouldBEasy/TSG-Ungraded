using SGBank.models;
using SGBank.models.Interfaces;
using SGBank.models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class FreeAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (response.Account._Type != AccountType.free)
            {
                response.success = false;
                response.message = "Error: a non-free account hit the Free Withdraw Rule. Contact IT";
                return response;
            }

            if (response.Amount >= 0)
            {
                response.success = false;
                response.message = "Withdrawal amounts must be negative!";
                return response;
            }

            if (response.Amount < -100)
            {
                response.success = false;
                response.message = "Free accounts cannot withdraw more than $100!";
                return response;
            }

            if ((response.Account._balance + amount) < 0)
            {
                response.success = false;
                response.message = "Free accounts cannot overdraft!";
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
