using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Hangman.Models.Interfaces;


namespace Hangman.Data
{
    public class DataRandom : IWordSelector
    {
        //Private properties
        private string _filePath = @"C:\Users\Cain\source\repos\TSG Ungraded\Hangman\Hangman\Data\wordlist.txt";
        private List<string> _wordList = new List<string>();

        //Constructor
        public DataRandom()
        {
            string line;

            using (StreamReader sr = new StreamReader(_filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    _wordList.Add(sr.ReadLine());
                }
            }
        }

        //Interface contract method
        public string GetWord()
        {
            Random wordSelector = new Random();
            int max = _wordList.Count();
            return _wordList.ElementAt(wordSelector.Next(0, max));
        }
    }
}
