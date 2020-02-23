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
    public class BasicAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if(account._Type != AccountType.basic)
            {
                response.success = false;
                response.message = "Error: a non-basic account hit hte Basic Withdraw Rule. Contact IT";
                return response;
            }

            if(amount >= 0)
            {
                response.success = false;
                response.message = "Withdrawal amounts must be negative!";
                return response;
            }

            if(amount < -500)
            {
                response.success = false;
                response.message = "Basic accounts cannot withdraw more than $500!";
                return response;
            }

            if((account._balance + amount) < -100)
            {
                response.success = false;
                response.message = "This amountw ill overdraft more than your $100 limit!";
                return response;
            }

            response.success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account._balance;
            account._balance += amount;
            if(account._balance < 0)
            {
                account._balance += -10;
            }
            return response;
        }
    }
}
