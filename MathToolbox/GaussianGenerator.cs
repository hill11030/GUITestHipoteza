using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathToolbox
{
    public class GaussianGenerator
    {
        /// <summary>
        /// Generates random values by Gaussian distribution, using the Box Muller transform (uniform to Gaussian)
        /// </summary>
        /// <param name="mu"></param>
        /// <param name="sigma"></param>
        /// <returns></returns>
        public double generateGaussianNoise(double mu, double sigma)
        {
            const double epsilon = (double)Int32.MinValue;
            const double two_pi = 2.0 * Math.PI;

            double z0 = 0, z1 = 0;
            bool generate = false;
            generate = !generate;

            if (!generate)
                return z1 * sigma + mu;

            double u1, u2;
            Random r = new Random();
            do
            {
                u1 = r.Next(0, Int32.MaxValue) * (1.0 / Int32.MaxValue);
                u2 = r.Next(0, Int32.MaxValue) * (1.0 / Int32.MaxValue);
            }
            while (u1 <= epsilon);

            z0 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(two_pi * u2);
            z1 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(two_pi * u2);
            return z0 * sigma + mu;
        }
    }
}
