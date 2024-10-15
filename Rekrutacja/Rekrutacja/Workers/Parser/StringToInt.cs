using System.Text.RegularExpressions;

namespace Rekrutacja.Workers.Parser
{
    public static class StringToInt
    {
        public static int Parse(string input)
        {
            if(input == null || input == string.Empty || !Regex.IsMatch(input, @"^\d+$"))
                return 0;

            var value = 0;
            for (int i = 0; i < input.Length; i++)
                value = value * 10 + (input[i] - '0');

            return value;
        }
    }
}
