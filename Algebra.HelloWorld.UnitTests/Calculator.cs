namespace Algebra.HelloWorld.UnitTests;

internal class Calculator
{
    public double CalculateVat(double amount)
    {
        return amount * 1.25;
    }

    public double CalculateTax(double amount, double tax)
    {
        return amount * 100 * tax / 100;
    }
}
