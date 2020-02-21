using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
