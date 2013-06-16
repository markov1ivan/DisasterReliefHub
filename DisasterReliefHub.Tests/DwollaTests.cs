using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DisasterReliefHub.Libraries;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DisasterReliefHub.Tests
{
    [TestClass]
    public class DwollaTests
    {
        [TestMethod]
        public void TestDwollaSend()
        {
            Dwolla dwolla = new Dwolla("8zYtJBBRqqmDAT5tQ9ETEMaDbiRqZ/WvTmIz3Ua8dIZXIgB3jT", "r5mkf/PFY8xffmhSd87TVmFcf7+uz48U1Ad3yyXt+8DUqC8oHN");
            var result = dwolla.Send("markov.ivan@gmail.com", 5, "Ivan", "Markov", "000000000", "000", DwollaAccountType.Checking);

            Assert.IsTrue(result != null && result.Success == "true");
        }
    }
}
