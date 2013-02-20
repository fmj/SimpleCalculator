using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        private SimpleCalculator.SimpleCalculator _calc;
        [TestInitialize]
        public void Setup()
        {
            _calc = new SimpleCalculator.SimpleCalculator();
        }

        [TestMethod]
        public void TestAddEmptyString()
        {
            
            Assert.AreEqual(_calc.Add(""), 0);
        }

        [TestMethod]
        public void TestAddOOneNumber()
        {
            Assert.AreEqual(_calc.Add("1"),1);
        }

        [TestMethod]
        public void TestAddTwoNumber()
        {
            Assert.AreEqual(_calc.Add("1,3"),4);
        }

        [TestMethod]
        public void TestAddXNumber()
        {
            Assert.AreEqual(_calc.Add("1,3,4,5,test"), 13);
        }

        [TestMethod]
        public void TestAddNumberSplitNewLine()
        {
            Assert.AreEqual(_calc.Add("1\n2,3"),6);
        }

        [TestMethod]
        public void TestMultipleSeperators()
        {
            try
            {
                _calc.Add("1,\n");
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail("No exception");
        }

        [TestMethod]
        public void VerifyJustNewLIneSeperator()
        {
            Assert.AreEqual(_calc.Add("2\n3\n3"),8);
        }
    }
}
