namespace Rekrutacja.Workers.Kalkulator
{
    public class Calculator
    {
        public double Calculate(double a, double b, OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.Addition:
                    return a + b;
                case OperationType.Subtraction:
                    return a - b;
                case OperationType.Multiplication:
                    return a * b;
                case OperationType.Division:
                    return b == 0 ? 0 : a / b;
            }

            return 0;
        }
    }
}
