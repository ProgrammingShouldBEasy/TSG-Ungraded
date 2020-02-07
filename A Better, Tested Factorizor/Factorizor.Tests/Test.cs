using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;
using NUnit.Framework;

namespace Factorizor.Tests
{
    [TestFixture]
    class Test
    {
        [TestCase(-1, new string[1] {"This number cannot be factored."})]
        [TestCase(0, new string[1] {"This number cannot be factored."})]
        [TestCase(6, new string[3] { "1 x 6 6.", "2 x 3 6.", "3 x 2 6."})]
        public void Factor (int x, string[] expected)
        {
            FindAndCheck test = new FindAndCheck();
            string[] actual = test.FactorFinder(x);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, true)]
        [TestCase(5, false)]
        [TestCase(-5, false)]
        public void Perfect (int x, bool expected)
        {
            FindAndCheck test = new FindAndCheck();
            bool actual = test.PerfectChecker(x);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-5, false)]
        [TestCase(0, false)]
        [TestCase(7, true)]
        public void Prime (int x, bool expected)
        {
            FindAndCheck test = new FindAndCheck();
            bool actual = test.PrimeChecker(x);

            Assert.AreEqual(expected, actual);
        }
    }
}
