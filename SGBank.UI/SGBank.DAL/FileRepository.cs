using SGBank.models;
using SGBank.models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.DAL
{
    public class FileRepository : IAccountRepository
    {
        private string _filePath = @"C:\Users\Cain\source\repos\TSG Ungraded\SGBank.UI\SGBank.DAL\Data\Accounts.txt";


        private string AccountToText(Account account)
        {
            return $"{account._number},{account._name},{account._balance},{account._Type.ToString().ToUpper()[0]}";
        }

        private List<Account> ReadAccountsfromFile()
        {
            using (StreamReader sr = new StreamReader(_filePath))
            {
                List<Account> list = new List<Account>();
                string[] columns;
                string line;

                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    Account account = new Account();
                    columns = line.Split(',');
                    account._number = columns[0];
                    account._name = columns[1];
                    account._balance = decimal.Parse(columns[2]);
                    switch (columns[3])
                    {
                        case "F":
                            account._Type = AccountType.free;
                            break;
                        case "B":
                            account._Type = AccountType.basic;
                            break;
                        case "P":
                            account._Type = AccountType.premium;
                            break;
                    }
                    list.Add(account);
                }

                return list;
            }
        }

        private void AccountsToFile(List<Account> list)
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (Account x in list)
                {
                    sw.WriteLine(AccountToText(x));
                }
            }
        }

        public Account LoadAccount(string AccountNumber)
        {
            return ReadAccountsfromFile().FirstOrDefault(x => x._number == AccountNumber);
        }

        public void SaveAccount(Account account)
        {
            List<Account> list = ReadAccountsfromFile();
            int index = list.FindIndex(x => x._number == account._number);
            list.RemoveAt(index);
            list.Add(account);
            AccountsToFile(list);
        }
    }
}
