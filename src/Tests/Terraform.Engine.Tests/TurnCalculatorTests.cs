using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Terraform.Engine.Tests
{
    [TestClass]
    public class TurnCalculatorTests
    {
        [TestMethod]
        public void Run_Turn_Calculation()
        {
            var calculator = new TurnCalculator();

            calculator.Calculate();
        }
    }
}
