using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.models;
using SGBank.models.Interfaces;

namespace SGBank.DAL
{
    public class PremiumAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account("Premium Account", "11111", 10000m, AccountType.premium);

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
