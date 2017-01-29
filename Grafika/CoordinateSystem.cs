namespace Grafika
{
    public class CoordinateSystem
    {
        #region Fields

        private double xmin;
        private double xmax;
        private double ymin;
        private double ymax;
        private int numXPoints;
        private int numYPoints;

        #endregion

        #region Properties

        public double XMin
        {
            get
            {
                return xmin;
            }
        }

        public double XMax
        {
            get
            {
                return xmax;
            }
        }

        public double YMin
        {
            get
            {
                return ymin;
            }
        }

        public double YMax
        {
            get
            {
                return ymax;
            }
        }

        public double NumXPoints
        {
            get
            {
                return numXPoints;
            }
        }
        public double NumYPoints
        {
            get
            {
                return numYPoints;
            }
        }

        public double Height
        {
            get
            {
                return this.ymax - this.ymin;
            }
        }

        public double Width
        {
            get
            {
                return this.xmax - this.xmin;
            }
        }

        #endregion

        #region Constructors

        public CoordinateSystem(double xmax, double ymax, int numXPoints, double xmin = 0, double ymin = 0, int numYPoints = 0)
        {
            this.xmin = xmin;
            this.xmax = xmax;
            this.numXPoints = numXPoints;
            this.ymin = ymin;
            this.ymax = ymax;
            this.numYPoints = (numYPoints == 0) ? numXPoints : numYPoints;
        } 

        #endregion
    }
}
