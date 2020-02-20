using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Data;
using Hangman.Models.Interfaces;
using System.Configuration;

namespace Hangman.Logic
{
    public class GameFactory
    {
        public static GameManager Create()
        {
            string selectorType = ConfigurationManager.AppSettings["Behavior"].ToString();

            if (selectorType == "Random")
                return new GameManager(new DataRandom());
            else if (selectorType == "Static")
                return new GameManager(new DataStatic());
            else
                throw new Exception("Selector key in app.config not set properly.");
        }
    }
}
