using SGBank.models;
using SGBank.models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.DepositRules
{
    public class DepositRulesFactory
    {
        public static IDeposit Create(AccountType type)
        {
            switch(type)
            {
                case AccountType.free:
                    return new FreeAccountDepositRule();
                case AccountType.basic:
                    return new NoLimitDepositRule();
                case AccountType.premium:
                    return new NoLimitDepositRule();
            }

            throw new Exception("Account type is not supported!");
        }
    }
}
