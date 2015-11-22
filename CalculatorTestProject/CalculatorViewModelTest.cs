using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RamekCalculator.ViewModels;

namespace CalculatorTestProject
{
    [TestClass]
    public class CalculatorViewModelTest
    {
        [TestMethod]
        public void TestAdd()
        {
            var c = new CalculatorViewModel();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('1');
            c.AddCommand.Execute();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('0');
            c.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(c.Result, 4.1M));
        }

        [TestMethod]
        public void TestSubstract()
        {
            var c = new CalculatorViewModel();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('0');
            c.SubtractCommand.Execute();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('1');
            c.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(c.Result, -0.1M));
        }

        [TestMethod]
        public void TestMultiply()
        {
            var c = new CalculatorViewModel();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('0');
            c.PlusMinusCommand.Execute();
            c.MultiplyCommand.Execute();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('0');
            c.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(c.Result, -4.0M));
        }

        [TestMethod]
        public void TestDivide()
        {
            var c = new CalculatorViewModel();
            c.InputSymbol('5'); c.InputSymbol(','); c.InputSymbol('0');
            c.PlusMinusCommand.Execute();
            c.DivideCommand.Execute();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('5');
            c.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(c.Result, -2.0M));
        }

        [TestMethod]
        public void TestMultiplyAndDivide()
        {
            var c = new CalculatorViewModel();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('0');
            c.PlusMinusCommand.Execute();
            c.MultiplyCommand.Execute();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('0');
            c.DivideCommand.Execute();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('0');
            c.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(c.Result, -2.0M));
        }

        [TestMethod]
        public void TestAddSubtractAndEquate()
        {
            var c = new CalculatorViewModel();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('1');
            c.PlusMinusCommand.Execute();
            c.AddCommand.Execute();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('0');
            c.SubtractCommand.Execute();
            c.InputSymbol('2'); c.InputSymbol(','); c.InputSymbol('0');
            c.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(c.Result, -2.1M));
        }

        [TestMethod]
        public void TestEmptyInput()
        {
            var c = new CalculatorViewModel();
            c.Input = String.Empty;
            Assert.IsTrue(c.Input == "0");
        }
    }
}
