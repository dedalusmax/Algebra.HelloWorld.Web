namespace Algebra.HelloWorld.Web.MvcApp.Test;

public class Calculator
{
    public double CalculateVat(double amount)
    {
        if (amount < 0)
            throw new ArgumentException("Negative number not allowed.");

        return Math.Round(amount * 1.25, 2);
    }

    public double CalculateTax(double amount, double tax)
    {
        return Math.Round(amount + amount * tax / 100, 2);
    }
}
