﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.models;
using SGBank.models.Interfaces;
using SGBank.models.Responses;

namespace SGBank.BLL
{
    public class AccountManager
    {
        private IAccountRepository _accountRepo;

        public AccountManager(IAccountRepository concrete)
        {
            _accountRepo = concrete;
        }

        public AccountLookUpResponse LookupAccount(string accountNumber)
        {
            AccountLookUpResponse response = new AccountLookUpResponse();

            response.Account = _accountRepo.LoadAccount(accountNumber);

            if(response.Account == null)
            {
                response.success = false;
                response.message = $"{accountNumber} is not a valid account.";
            }
            else
            {
                response.success = true;
            }
            return response;
        }

        public AccountDepositResponse Deposit(string accountNumber, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            response.Account = _accountRepo.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.success = false;
                response.message = $"{accountNumber} is not a valid account.";
                return response;
            }
            else
            {
                response.success = true;
            }

            IDeposit depositRule = DepositRulesFactory.Create(response.Account._Type);
            response = depositRule.Deposit(response.Account, amount);

            if(response.success)
            {
                _accountRepo.SaveAccount(response.Account);
            }

            return response;
        }

        public AccountWithdrawResponse WithdrawRules(string accountNumber, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            response.Account = _accountRepo.LoadAccount(accountNumber);

            if(response.Account == null)
            {
                response.success = false;
                response.message = "Account number is not valid.";
                return response;
            }

            IWithdraw withdraw = WithdrawRulesFactory.Create(response.Account._Type);
            response = withdraw.Withdraw(response.Account, amount);

            if (response.success)
            {
                _accountRepo.SaveAccount(response.Account);
            }

            return response;
        }
    }
}
