using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._2
{
    public static class QuadraticEquationSolver
    {
        public static double[] Solve(double a, double b, double c)
        {
            if (Math.Abs(a) < double.Epsilon)
            {
                throw new ArgumentException("Coefficient 'a' cannot be zero in quadratic equation.");
            }

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double x1 = (-b + sqrtDiscriminant) / (2 * a);
                double x2 = (-b - sqrtDiscriminant) / (2 * a);
                return new[] { x1, x2 };
            }
            else if (Math.Abs(discriminant) < double.Epsilon)
            {
                double x = -b / (2 * a);
                return new[] { x };
            }
            else
            {
                return Array.Empty<double>();
            }
        }
    }
}
