using SGBank.models;
using SGBank.models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class WithdrawRulesFactory
    {
        public static IWithdraw Create(AccountType type)
        {
            switch(type)
            {
                case AccountType.free:
                    return new FreeAccountWithdrawRule();
                default:
                    throw new Exception("Account type is not supported!");
            }
        }
    }
}
