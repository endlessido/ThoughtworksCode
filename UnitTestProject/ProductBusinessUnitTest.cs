using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosPrintComponent.Business;

namespace UnitTestProject
{
    [TestClass]
    public class ProductBusinessUnitTest
    {
        [TestMethod]
        public void TestPrintResult()
        {
            string[] isbnArray = {"000001","ITEM000001"};
            ProductsBusiness service = new ProductsBusiness();
            bool actual = service.CheckData(isbnArray);
            Assert.AreEqual(actual, false);
        }
    }
}
