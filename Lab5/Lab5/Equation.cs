using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public abstract partial class Equation
    {
        public abstract double Calculate(double x);
    }

    public class QuadraticEquation : Equation
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public QuadraticEquation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override double Calculate(double x)
        {
            return A * x * x + B * x + C;
        }
    }

    public class SinEquation : Equation
    {
        public double A { get; set; }

        public SinEquation(double a)
        {
            A = a;
        }

        public override double Calculate(double x)
        {
            if (Math.Abs(x) < 1e-10)
                return double.NaN;
            return Math.Sin(A * x) / x;
        }
    }

    public abstract class Integrator
    {
        public abstract double Integrate(Equation equation, double x1, double x2, int n);
    }

    public class RectangleIntegrator : Integrator
    {
        public override double Integrate(Equation equation, double x1, double x2, int n)
        {
            if (n <= 0) throw new ArgumentException("Число разбиений должно быть положительным");

            double h = (x2 - x1) / n;
            double sum = 0.0;

            for (int i = 0; i < n; i++)
            {
                double x = x1 + i * h;
                sum += equation.Calculate(x);
            }

            return sum * h;
        }
    }

    public class TrapezoidalIntegrator : Integrator
    {
        public override double Integrate(Equation equation, double x1, double x2, int n)
        {
            if (n <= 0) throw new ArgumentException("Число разбиений должно быть положительным");

            double h = (x2 - x1) / n;
            double sum = (equation.Calculate(x1) + equation.Calculate(x2)) / 2;

            for (int i = 1; i < n; i++)
            {
                double x = x1 + i * h;
                sum += equation.Calculate(x);
            }

            return sum * h;
        }
    }

    public static class FunctionDataGenerator
    {
        public static (double[] x, double[] y) GenerateFunctionData(double x1, double x2, Equation equation)
        {
            int pointsCount = 1000;
            double[] xValues = new double[pointsCount + 1];
            double[] yValues = new double[pointsCount + 1];

            double step = (x2 - x1) / pointsCount;

            for (int i = 0; i <= pointsCount; i++)
            {
                double x = x1 + i * step;
                xValues[i] = x;

                try
                {
                    double y = equation.Calculate(x);
                    yValues[i] = double.IsNaN(y) || double.IsInfinity(y) ? 0 : y;
                }
                catch
                {
                    yValues[i] = 0;
                }
            }

            return (xValues, yValues);
        }
    }
}
