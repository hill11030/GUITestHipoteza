using System;
using System.Collections.Generic;

namespace FGV
{
    class PolynomialFunction: IFunction
    {
        #region Fields

        private List<double> coefficients;

        #endregion

        #region Properties

        public List<double> Coefficients
        {
            get
            {
                if(coefficients == null)
                {
                    coefficients = new List<double> ();
                }

                return coefficients;
            }
        }

        #endregion

        #region Constructors

        public PolynomialFunction(List<double> coefs)
        {
            coefficients = new List<double>(coefs);
        }

        public PolynomialFunction(PolynomialFunction pol)
        {
            coefficients = new List<double>(pol.Coefficients);
        }

        #endregion

        #region Overrides

        public double GetValue(double x)
        {
            int n = Coefficients.Count - 1;
            double result = 0;

            foreach (double coeficient in Coefficients)
            {
                result += (coeficient * Math.Pow(x, n));
                n--;
            }

            return result;
        }

        #endregion

    }
}
