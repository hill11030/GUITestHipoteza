using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGV
{
    public class TemplateFunction
    {
        protected Func<double, double> funcExpression;
        public Func<double, double> Function
        {
            get
            {
                return funcExpression;
            }
        }

        public TemplateFunction(Func<double, double> func)
        {
            this.funcExpression = func;
        }

        /// <summary>
        /// Evaluate function expression for 'x'
        /// </summary>
        /// <param name="x">Input value</param>
        /// <returns></returns>
        public double GetValue(double x)
        {
            return Function(x);
        }

        #region Operator overloading
        public static TemplateFunction operator +(TemplateFunction f1, TemplateFunction f2)
        {
            Func<double, double> addition = x => f1.Function(x) + f2.Function(x);
            return new TemplateFunction(addition);
        }
        public static TemplateFunction operator -(TemplateFunction f1, TemplateFunction f2)
        {
            Func<double, double> subtract = x => f1.Function(x) - f2.Function(x);
            return new TemplateFunction(subtract);
        }
        public static TemplateFunction operator *(TemplateFunction f1, TemplateFunction f2)
        {
            Func<double, double> subtract = x => f1.Function(x) * f2.Function(x);
            return new TemplateFunction(subtract);
        }
        public static TemplateFunction operator /(TemplateFunction f1, TemplateFunction f2)
        {
            Func<double, double> subtract = x => f1.Function(x) / f2.Function(x);
            return new TemplateFunction(subtract);
        }
        #endregion
    }
}
