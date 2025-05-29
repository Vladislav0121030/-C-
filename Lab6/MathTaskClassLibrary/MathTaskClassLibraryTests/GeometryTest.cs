using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathTaskClassLibrary;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class GeometryTest
    {
        [TestMethod]
        public void CalculateAreaTest()
        {
            int a = 3;
            int b = 5;
            int expected = 15;

            Geometry g = new Geometry();
            int actual = g.CalculateArea(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAreaTest1()
        {
            bool catched = false;
            try
            {
                int a = -4;
                int b = 10;

                Geometry g = new Geometry();
                int actual = g.CalculateArea(a, b);
            }
            catch
            {
                catched = true;
            }
            Assert.IsTrue(catched, "Не обработаны доступные данные");
        }
            [TestMethod]
            public void CalculateAreaTest2()
            {
                    int a = -4;
                    int b = 10;

                    Geometry g = new Geometry();
            Assert.ThrowsException<ArgumentException>(() => g.CalculateArea(a, b), "Не обработаны отрицательные длины сторон прямоугольника");
        }
    }
}
