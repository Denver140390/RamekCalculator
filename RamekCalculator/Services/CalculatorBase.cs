using System;

namespace RamekCalculator.Services
{
    public abstract class CalculatorBase
    {
        public Decimal Add(Decimal v1, Decimal v2)
        {
            Decimal result = Decimal.Add(v1, v2);
            return result;
        }

        public Decimal Subtract(Decimal v1, Decimal v2)
        {
            Decimal result = Decimal.Subtract(v1, v2);
            return result;
        }

        public Decimal Multiply(Decimal v1, Decimal v2)
        {
            Decimal result = Decimal.Multiply(v1, v2);
            return result;
        }

        public Decimal Divide(Decimal v1, Decimal v2)
        {
            Decimal result = Decimal.Divide(v1, v2);
            return result;
        }
    }
}