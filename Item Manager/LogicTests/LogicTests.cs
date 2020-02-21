using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Compatibility;
using Item_Manager.Logic;
using Item_Manager.Data;
using Item_Manager.Models;
using System.IO;

namespace Item_Manager.Tests
{
    [TestFixture]
    public class LogicTests
    {
        Features processor = FeaturesFactory.Create();

        [Test]
        public void GetBook()
        {
            bool testBool = true;
            Assert.AreEqual("book name name name", processor.SearchByIndex(0, out testBool).Title);

        }

    }
}
