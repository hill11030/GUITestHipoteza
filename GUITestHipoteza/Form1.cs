using System.Windows.Forms;
using System.Drawing;
using System;
using System.Linq;
using Grafika;
using System.Configuration;
using MathToolbox;

namespace GUITestHipoteza
{
    public partial class Form1 : Form
    {
        private bool isFirst = true;

        public Form1()
        {
            InitializeComponent();

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Size = new Size(550, 550);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //int podela = Convert.ToInt32(ConfigurationManager.AppSettings["Podela"].ToString());
            //Plotter cs = new Plotter(e.Graphics);
            //cs.DrawCoordinateSystem(System.Drawing.Pens.Red, new System.Drawing.Rectangle(10, 30, 500, 500), new CoordinateSystem(100, 100, podela, -100, 0, 20));
            if (isFirst)
            {
                TempDraw();
                isFirst = false;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            TempDraw();
        }

        private void TempDraw()
        {
            int podela = Convert.ToInt32(ConfigurationManager.AppSettings["Podela"].ToString());

            var graphics = this.CreateGraphics();
            graphics.Clear(this.BackColor);

            int height = (int)(this.Height * 0.7);
            int width = (int)(this.Width * 0.9);

            Plotter cs = new Plotter(graphics, Brushes.White, new System.Drawing.Rectangle(10, 30, width, height), new CoordinateSystem(100, 100, podela, -100, 0, 20));

            cs.DrawCoordinateSystem(System.Drawing.Pens.Red);

            Point[] points = new Point[50];
            Random r = new Random();
            int devX = 50, devY = 30;
            Point mean = new Point(100, 50);
            for (int i = 0; i < points.Length; i++)
            {
                Point newPoint = new Point(mean.X + (int)(devX * r.NextDouble()), mean.Y + (int)(devY * r.NextDouble()));
                points[i] = newPoint;
            }

            cs.DrawPoints(points);


            double gMean = 50;
            double gSigma = 5;
            GaussianGenerator gauss = new GaussianGenerator();

            double[] vals = new double[100];
            for (int i = 0; i < vals.Length; i++)
            {
                vals[i] = gauss.generateGaussianNoise(gMean, gSigma);
                System.Threading.Thread.Sleep(15);
            }

            //cs.DrawFunction(new ExponencialFunction(3, 0));

            int ls3 = vals.Where(v => v >= gMean - 3 * gSigma && v < gMean - 2 * gSigma).Count();
            int ls2 = vals.Where(v => v >= gMean - 2 * gSigma && v < gMean - 1 * gSigma).Count();
            int ls1 = vals.Where(v => v >= gMean - 1 * gSigma && v < gMean ).Count();
            int gs1 = vals.Where(v => v >= gMean && v < gMean + 1 * gSigma).Count();
            int gs2 = vals.Where(v => v >= gMean + 1 * gSigma && v < gMean + 2 * gSigma).Count();
            int gs3 = vals.Where(v => v >= gMean + 2 * gSigma && v < gMean + 3 * gSigma).Count();
        }
    }
}
