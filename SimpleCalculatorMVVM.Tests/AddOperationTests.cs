using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationDLL1;

namespace SimpleCalculatorMVVM.Tests
{
    [TestClass]
    public class AddOperationTests
    {
        [TestMethod]
        [DataRow(10, 3, 13)]   // обычные положительные числа
        [DataRow(-5, -2, -7)]  // отрицательные числа
        [DataRow(-5, 5, 0)]    // сумма в ноль
        [DataRow(0, 7, 7)]     // ноль + число
        [DataRow(3.5, 2.2, 5.7)] // числа с плавающей точкой
        public void Calculate_AddNumbers_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange
            IOperation operation = new AddOperation();

            // Act
            double result = operation.Calculate(a, b);

            // Assert
            Assert.AreEqual(expected, result, 1e-10, "Ошибка при сложении");
        }
    }
}
