namespace Algebra.HelloWorld.UnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void TestCalculateVat_IntegerAmount_TaxCorrect()
        {
            // Arrange
            var calc = new Calculator();
            var input = 100;

            // Act
            var result = calc.CalculateVat(input);

            // Assert
            Assert.IsType<double>(result);
            Assert.NotEqual(input, result);
            // Assert.True(result == 100);
            Assert.Equal(input * 1.25, result);
        }

        [Fact]
        public void TestCalculateVat_DecimalPointAmount_TaxCorrect()
        {

        }

        [Fact]
        public void TestCalculateVat_Zero_TaxCorrect()
        {

        }

        [Fact]
        public void TestCalculateVat_NegativeAmount_TaxCorrect()
        {

        }
    }
}