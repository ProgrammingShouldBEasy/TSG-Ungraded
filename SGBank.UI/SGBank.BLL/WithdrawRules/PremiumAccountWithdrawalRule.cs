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
    public class PremiumAccountWithdrawalRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account._Type != AccountType.premium)
            {
                response.success = false;
                response.message = "Error: a non-premium account hit the Premium Withdraw Rule. Contact IT";
                return response;
            }

            if (amount >= 0)
            {
                response.success = false;
                response.message = "Withdrawal amounts must be negative!";
                return response;
            }

            if ((account._balance + amount) < -500)
            {
                response.success = false;
                response.message = "This amount will overdraft more than your $500 limit!";
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
