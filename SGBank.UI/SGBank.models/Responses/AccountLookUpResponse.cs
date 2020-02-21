using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.models.Responses;

namespace SGBank.models.Responses
{
    public class AccountLookUpResponse : Response
    {
        public Account Account { get; set; }
    }
}
