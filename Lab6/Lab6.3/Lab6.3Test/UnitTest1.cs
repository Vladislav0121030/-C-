using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab6._3;

namespace Lab6._3Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class YearDaysCalculatorTests
        {
            [TestMethod]
            [DataRow(2023, 365)] 
            [DataRow(2024, 366)] 
            [DataRow(1900, 365)] 
            [DataRow(2000, 366)] 
            [DataRow(1, 365)]    
            [DataRow(4, 366)] 
            public void GetDaysInYear_ValidYears_ReturnsCorrectDays(int year, int expectedDays)
            {
                var result = YearDaysCalculator.GetDaysInYear(year);
                Assert.AreEqual(expectedDays, result);
            }

            [TestMethod]
            [DataRow(0)]
            [DataRow(-1)]
            [DataRow(-100)]
            public void GetDaysInYear_InvalidYears_ThrowsArgumentOutOfRangeException(int year)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => YearDaysCalculator.GetDaysInYear(year));
            }

            [TestMethod]
            public void GetDaysInYear_NonLeapCenturyYear_Returns365()
            {
             
                int year = 1900;
                int expected = 365;

             
                var result = YearDaysCalculator.GetDaysInYear(year);

             
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void GetDaysInYear_LeapCenturyYear_Returns366()
            {
             
                int year = 2000;
                int expected = 366;

             
                var result = YearDaysCalculator.GetDaysInYear(year);

             
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void GetDaysInYear_RegularLeapYear_Returns366()
            {
            
                int year = 2020;
                int expected = 366;

            
                var result = YearDaysCalculator.GetDaysInYear(year);

            
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void GetDaysInYear_RegularNonLeapYear_Returns365()
            {
            
                int year = 2021;
                int expected = 365;

            
                var result = YearDaysCalculator.GetDaysInYear(year);

            
                Assert.AreEqual(expected, result);
            }
        }
    }
}
