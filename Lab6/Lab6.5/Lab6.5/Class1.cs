using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._5
{
    public static class DigitSumCalculator
    {
        public static int CalculateDigitSum(string numberString)
        {
            if (string.IsNullOrWhiteSpace(numberString))
            {
                throw new ArgumentException("Input string cannot be null or empty");
            }

            if (!numberString.All(char.IsDigit))
            {
                throw new ArgumentException("Input string must contain only digits");
            }

            if (numberString.StartsWith("0") && numberString.Length > 1)
            {
                throw new ArgumentException("Number cannot have leading zeros");
            }

            return numberString.Sum(c => c - '0');
        }
    }
    

}
