using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab6._2;

namespace Lab6._2Test
{
    [TestClass]
    public class QuadraticEquationSolverTests
    {
        private const double Tolerance = 0.01;

        [TestMethod]
        [DataRow(1, -3, 2, new[] { 2.0, 1.0 })] 
        [DataRow(1, -2, 1, new[] { 1.0 })]       
        [DataRow(1, 2, 5, new double[0])]      
        [DataRow(2, -11, 5, new[] { 5.0, 0.5 })] 
        public void Solve_ValidCoefficients_ReturnsCorrectRoots(double a, double b, double c, double[] expected)
        {
      
            var result = QuadraticEquationSolver.Solve(a, b, c);

        
            Assert.AreEqual(expected.Length, result.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i], Tolerance);
            }
        }

        [TestMethod]
        [DataRow(0, 1, 1)]
        [DataRow(0, 0, 1)]
        [DataRow(0, 1, 0)]
        public void Solve_ZeroA_ThrowsArgumentException(double a, double b, double c)
        {
        
            Assert.ThrowsException<ArgumentException>(() => QuadraticEquationSolver.Solve(a, b, c));
        }

        [TestMethod]
        public void Solve_LinearEquation_ThrowsArgumentException()
        {
     
            double a = 0, b = 1, c = -5;

      
            Assert.ThrowsException<ArgumentException>(() => QuadraticEquationSolver.Solve(a, b, c));
        }

        [TestMethod]
        public void Solve_NoRealRoots_ReturnsEmptyArray()
        {
      
            double a = 1, b = 0, c = 1;
            double[] expected = Array.Empty<double>();

          
            var result = QuadraticEquationSolver.Solve(a, b, c);

         
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Solve_OneRealRoot_ReturnsSingleElementArray()
        {
         
            double a = 1, b = -2, c = 1;
            double[] expected = { 1.0 };


            var result = QuadraticEquationSolver.Solve(a, b, c);

         
            Assert.AreEqual(expected.Length, result.Length);
            Assert.AreEqual(expected[0], result[0], Tolerance);
        }
    }
}
