using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1
{
    public static class AlphabetGenerator
    {
        public static string GenerateUppercaseLetters(int n)
        {
            if (n < 1 || n > 26)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "N should be between 1 and 26");
            }

            return new string(Enumerable.Range(0, n).Select(i => (char)('A' + i)).ToArray());
        }
    }
}
