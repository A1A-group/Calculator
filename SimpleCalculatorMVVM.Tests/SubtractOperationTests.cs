using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationDLL1;

namespace SimpleCalculatorMVVM.Tests
{
    [TestClass]
    public class SubtractOperationTests
    {
        [TestMethod]
        public void Calculate_SubtractsTwoNumbers_ReturnsCorrectResult()
        {
            IOperation operation = new SubtractOperation();
            double result = operation.Calculate(10, 3);
            Assert.AreEqual(7, result);
        }
    }
}
