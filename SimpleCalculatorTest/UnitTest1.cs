using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDelimNumber()
        {
            Assert.AreEqual(_calc.Add("//[12][3]\n412537"), 16);
        }

        [TestMethod]
        public void TestMultipleNewDelims()
        {
            Assert.AreEqual(_calc.Add("//[*][%]\n1*2%3"),6);
        }

        [TestMethod]
        public void TestMultipleLotsLongNewDelims()
        {
            Assert.AreEqual(_calc.Add("//[KodeCata][Per][Erik][Andreas]\n1Per2Erik3Andreas4KodeCata2"), 12);
        }

        [TestMethod]
        public void TestMultipleNewLongDelims()
        {
            Assert.AreEqual(_calc.Add("//[Per][Erik]\n1Erik2Per3"), 6);
        }
        [TestMethod]
        public void TestAnyLongSep()
        {
            Assert.AreEqual(_calc.Add("//test\n2test4test6"),12);
        }
        [TestMethod]
        public void AddBigNumbers()
        {
            Assert.AreEqual(_calc.Add("1000,1001,2,4"),1006);
        }
        [TestMethod]
        public void AddNegativeNumberFail()
        {
            try
            {
                _calc.Add("-2,-3");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                if(!(ex.Message.Contains("-2") && ex.Message.Contains("-3")))
                {
                    Assert.Fail("Errormessage did not contain the numbers");
                }
                return;
            }
            Assert.Fail("Negative numbers not recognized");
        }

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

        [TestMethod]
        public void SupportRandomSeperators()
        {
            Assert.AreEqual(_calc.Add("//;\n1;2;3;4"),10);
        }
    }
}
