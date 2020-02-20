using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Data;
using Hangman.Models.Interfaces;

namespace Hangman.Logic
{
    public class GameManager
    {
        private IWordSelector _selector;

        public GameManager(IWordSelector concrete)
        {
            _selector = concrete;
        }

        public string ReturnWord()
        {
            return _selector.GetWord();
        }
    }
}
