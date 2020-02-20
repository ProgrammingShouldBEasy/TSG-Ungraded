using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Models.Interfaces;

namespace Hangman.Data
{
    public class DataStatic : IWordSelector
    {
        public string GetWord()
        {
            return "antidisestablishmentarianism";
        }
    }
}
