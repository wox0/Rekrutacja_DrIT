namespace Rekrutacja.Workers.Kalkulator
{
    public enum OperationType
    {
        None,
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }

    public static class OperationConverter
    {
        public static OperationType Convert(string operationString)
        {
            switch (operationString)
            {
                case "+":
                    return OperationType.Addition;
                case "-":
                    return OperationType.Subtraction;
                case "*":
                    return OperationType.Multiplication;
                case "/":
                    return OperationType.Division;
            }

            return OperationType.None;
        }
    }
}
