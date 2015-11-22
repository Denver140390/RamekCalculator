using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RamekCalculator;
using RamekCalculator.Services;

namespace CalculatorTestProject
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestAdd()
        {
            var calculator = new CalculatorSimple();
            Decimal result = calculator.Add(-2.1M, 2.0M);
            Assert.IsTrue(Decimal.Equals(result, -0.1M));
        }

        [TestMethod]
        public void TestSubstract()
        {
            var calculator = new CalculatorSimple();
            Decimal result = calculator.Subtract(-2.1M, 2.0M);
            Assert.IsTrue(Decimal.Equals(result, -4.1M));
        }

        [TestMethod]
        public void TestMultiply()
        {
            var calculator = new CalculatorSimple();
            Decimal result = calculator.Multiply(-2.0M, 2.0M);
            Assert.IsTrue(Decimal.Equals(result, -4.0M));
        }

        [TestMethod]
        public void TestDivide()
        {
            var calculator = new CalculatorSimple();
            Decimal result = calculator.Divide(-5.0M, 2.5M);
            Assert.IsTrue(Decimal.Equals(result, -2.0M));
        }
    }
}
