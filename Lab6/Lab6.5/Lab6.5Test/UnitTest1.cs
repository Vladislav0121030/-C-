using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab6._5;

namespace Lab6._5Test
{
        [TestClass]
        public class DigitSumCalculatorTests
        {
            [TestMethod]
            [DataRow("123", 6)]
            [DataRow("999", 27)]
            [DataRow("1000", 1)]
            [DataRow("5", 5)]
            [DataRow("1111111111", 10)]
            public void CalculateDigitSum_ValidNumbers_ReturnsCorrectSum(string numberString, int expected)
            {
                var result = DigitSumCalculator.CalculateDigitSum(numberString);
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            [DataRow(null)]
            [DataRow("")]
            [DataRow("   ")]
            public void CalculateDigitSum_NullOrEmpty_ThrowsArgumentException(string input)
            {
                Assert.ThrowsException<ArgumentException>(() => DigitSumCalculator.CalculateDigitSum(input));
            }

            [TestMethod]
            [DataRow("12a3")]
            [DataRow("1.23")]
            [DataRow("-123")]
            [DataRow(" 123 ")]
            public void CalculateDigitSum_NonDigitCharacters_ThrowsArgumentException(string input)
            {
                Assert.ThrowsException<ArgumentException>(() => DigitSumCalculator.CalculateDigitSum(input));
            }

            [TestMethod]
            [DataRow("0123")]
            [DataRow("00")]
            public void CalculateDigitSum_LeadingZeros_ThrowsArgumentException(string input)
            {
                Assert.ThrowsException<ArgumentException>(() => DigitSumCalculator.CalculateDigitSum(input));
            }

            [TestMethod]
            public void CalculateDigitSum_SingleZero_ReturnsZero()
            {
                string input = "0";
                int expected = 0;
                var result = DigitSumCalculator.CalculateDigitSum(input);
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void CalculateDigitSum_LongNumber_ReturnsCorrectSum()
            {
                string input = "12345678901234567890";
                int expected = 90;
                var result = DigitSumCalculator.CalculateDigitSum(input);
                Assert.AreEqual(expected, result);
            }
        }
    }
