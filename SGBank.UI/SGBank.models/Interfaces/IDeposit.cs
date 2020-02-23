using SGBank.models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.models.Interfaces
{
    public interface IDeposit
    {
        AccountDepositResponse Deposit(Account account, decimal amount);
    }
}
