using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._3
{
    public static class YearDaysCalculator
    {
        public static int GetDaysInYear(int year)
        {
            if (year <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be a positive integer");
            }

            if (year % 4 != 0)
            {
                return 365;
            }
            else if (year % 100 != 0)
            {
                return 366;
            }
            else if (year % 400 == 0)
            {
                return 366;
            }
            else
            {
                return 365;
            }
        }
    }
}