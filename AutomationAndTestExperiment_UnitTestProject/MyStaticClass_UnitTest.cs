using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationAndTestExperiment_UnitTestProject
{
    [TestClass]
    public class MyStaticClass_UnitTest
    {
        [TestMethod]
        public void SayHi_TestMethod()
        {
            string result = AutomationAndTestExperiment_PortableClassLib
                .MyStaticClass.SayHi();
            Assert.AreEqual("Hi", result);
        }
    }
}
