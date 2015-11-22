using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RamekCalculator;
using RamekCalculator.ViewModels;

namespace CalculatorTestProject
{
    [TestClass]
    public class CalculatorViewModelTest
    {
        [TestMethod]
        public void TestAdd()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.Input = "-2,1";
            calculatorViewModel.AddCommand.Execute();
            calculatorViewModel.Input = "2,0";
            calculatorViewModel.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(calculatorViewModel.Result, -0.1M));
        }

        [TestMethod]
        public void TestSubstract()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.Input = "-2,1";
            calculatorViewModel.SubtractCommand.Execute();
            calculatorViewModel.Input = "2,0";
            calculatorViewModel.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(calculatorViewModel.Result, -4.1M));
        }

        [TestMethod]
        public void TestMultiply()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.Input = "-2,0";
            calculatorViewModel.MultiplyCommand.Execute();
            calculatorViewModel.Input = "2,0";
            calculatorViewModel.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(calculatorViewModel.Result, -4.0M));
        }

        [TestMethod]
        public void TestDivide()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.Input = "-5,0";
            calculatorViewModel.DivideCommand.Execute();
            calculatorViewModel.Input = "2,5";
            calculatorViewModel.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(calculatorViewModel.Result, -2.0M));
        }

        [TestMethod]
        public void TestMultiplyAndDivide()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.Input = "-2,0";
            calculatorViewModel.MultiplyCommand.Execute();
            calculatorViewModel.Input = "2,0";
            calculatorViewModel.DivideCommand.Execute();
            calculatorViewModel.Input = "2,0";
            calculatorViewModel.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(calculatorViewModel.Result, -2.0M));
        }

        [TestMethod]
        public void TestAddSubtractAndEquate()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.Input = "-2,1";
            calculatorViewModel.AddCommand.Execute();
            calculatorViewModel.Input = "2,0";
            calculatorViewModel.SubtractCommand.Execute();
            calculatorViewModel.Input = "2,0";
            calculatorViewModel.EquateCommand.Execute();
            Assert.IsTrue(Decimal.Equals(calculatorViewModel.Result, -2.1M));
        }
    }
}
