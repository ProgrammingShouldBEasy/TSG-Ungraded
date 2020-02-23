using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.models;
using SGBank.models.Interfaces;

namespace SGBank.DAL
{
    public class FreeAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account("Free Account", "12345", 100m, AccountType.free);

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
