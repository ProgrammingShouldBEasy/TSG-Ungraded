using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Logic;
using NUnit.Framework;
using System.Configuration;

namespace Hangman.Tests
{
    [TestFixture]
    public class HangmanTests
    {
        [Test]
        public void IsStatic()
        {
            Assert.AreEqual("antidisestablishmentarianism", GameFactory.Create().ReturnWord());
        }
    }
}
