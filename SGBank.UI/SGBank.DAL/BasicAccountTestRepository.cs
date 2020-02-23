using SGBank.models;
using SGBank.models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.DAL
{
    public class BasicAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account("Basic Account", "33333", 100M, AccountType.basic);
        public Account LoadAccount(string AccountNumber)
        {
            if (_account._number == AccountNumber)
            {
                return _account;
            }
            else
            {
                return null;
            }
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
