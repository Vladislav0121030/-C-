using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab6._1;

namespace Lab6._1Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class UppercaseLettersGeneratorTests
        {
            [TestMethod]
            [DataRow(1, "A")]
            [DataRow(3, "ABC")]
            [DataRow(5, "ABCDE")]
            [DataRow(26, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
            public void GenerateUppercaseLetters_ValidInput_ReturnsCorrectString(int n, string expected)
            {
                var result = AlphabetGenerator.GenerateUppercaseLetters(n);
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            [DataRow(0)]
            [DataRow(-1)]
            [DataRow(27)]
            [DataRow(100)]
            public void GenerateUppercaseLetters_InvalidInput_ThrowsArgumentOutOfRangeException(int n)
            { 
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => AlphabetGenerator.GenerateUppercaseLetters(n));
            }

            [TestMethod]
            public void GenerateUppercaseLetters_EdgeCaseMinimum_ReturnsSingleA()
            {
                int n = 1;
                string expected = "A";
                var result = AlphabetGenerator.GenerateUppercaseLetters(n);
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void GenerateUppercaseLetters_EdgeCaseMaximum_ReturnsFullAlphabet()
            {
                int n = 26;
                string expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                var result = AlphabetGenerator.GenerateUppercaseLetters(n);
                Assert.AreEqual(expected, result);
            }
        }
    }
}
