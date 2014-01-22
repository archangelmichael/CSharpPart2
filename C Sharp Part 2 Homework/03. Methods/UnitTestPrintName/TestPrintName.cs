using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPrintName
{
    [TestClass]
    public class TestPrintName
    {
        [TestMethod]
        public void PrintHelloName()
        {
            string result = PrintName.PrintHelloName("Name");
            Assert.AreEqual(result, "Hello, Name!");
        }
        public void PrintNameWithDigits()
        {
            string result = PrintName.PrintHelloName("Name123");
            Assert.AreEqual(result, "Invalid input!");
        }
    }
}
