using System;

namespace FGV
{
    public class ExponencialFunction : IFunction
    {
        #region Fields

        private double sigma;
        private double micro;

        #endregion

        #region Properties

        public double Sigma
        {
            get
            {
                return sigma;
            }
        }

        public double Micro
        {
            get
            {
                return micro;
            }
        }

        #endregion

        #region Constructors

        public ExponencialFunction(double sigma, double micro)
        {
            this.sigma = sigma;
            this.micro = micro;
        }

        public ExponencialFunction(ExponencialFunction exp)
        {
            sigma = exp.Sigma;
            micro = exp.Micro;
        }

        #endregion

        #region Overrides

        public double GetValue(double x)
        {
            return 1 / (Sigma * Math.Sqrt(2 * Math.PI)) * Math.Exp(-0.5 * Math.Pow((x - Micro) / Sigma, 2));
        }

        #endregion

    }
}
