using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DisasterReliefHub.Twilio;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DisasterReliefHub.Tests
{
    [TestClass]
    public class TwilioTests
    {
        [TestMethod]
        public void TestSms()
        {
            TwilioManager manager = new TwilioManager("AC33f67bc4a21659e0be9754b789d9da4d", "e4dd86b2fd560201834d943be00a1df5");
            manager.SetSms("+18164795133", "+19139386633", "Wake up!!!!");
            manager.SetSms("+18164795133", "+18162777113", "Wake up!!!!");
        }
    }
}
