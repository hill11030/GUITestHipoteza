using FGV;
using Grafika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGUI
{
    public partial class MainForm : Form
    {
        private TemplateFunction f;
        private List<Point> points;
        private CoordinateSystem coordSystem;

        public MainForm()
        {
            InitializeComponent();

            coordSystem = new CoordinateSystem(50, 50, 100, -50, -50, 100);

            Func<double, double> expr = x => x;
            f = new TemplateFunction(expr);

            // generate points with function values
            points = new List<Point>();
            for (int i = -50; i <= 50; i++)
            {
                points.Add(new Point(i, (int)f.GetValue(i)));
            }

            // reverse Y, because of Forms coordinate system
            for (int i = 0; i < points.Count; i++)
            {
                Point p = points[i];
                p.Y = -p.Y;
                points[i] = p;
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //test
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            var g = this.CreateGraphics();
            g.Clear(this.BackColor);

            // set the coordinate system to center of client area
            g.TranslateTransform(this.ClientSize.Width / 2, this.ClientSize.Height / 2);

            g.DrawRectangle(Pens.Black, new Rectangle(-(int)coordSystem.Width / 2, -(int)coordSystem.Height / 2, (int)coordSystem.Width, (int)coordSystem.Height));

            foreach (Point p in points)
            {
                g.DrawRectangle(Pens.Red, new Rectangle(p, new Size(1, 1)));
            }
        }


        // 2016-12-17:
        //      Pozicioniraj koordinatni sistem na sredinu (testiraj kada abs(XMax) != abs(XMin) i abs(YMax) != abs(YMin)
        //      Iscrtaj podelu (brojeve i recke)
        //      Dodaj podrsku za iscrtavanje osa (bleda siva boja, da ne smeta)
        //      Oboji pozadinu
        //      Razmotriti skaliranje (da se pre sirenju ne desi prevelika pikselizacija)
        //      Ograniciti iscrtavanje grafika (i tacaka) na [CoordinateSystem.YMin, CoordinateSystem.YMax]

        // 2. faza
        //      crtati tacke 2 klase raspodeljenje po normalnoj i/ili uniformnoj raspodeli
        //      generisati funkciju klasifikatora na osnovu FVG dve klase

        // 3. faza
        //      Sprovesti svaki test hipoteze

        // 4. faza
        //      Refactor, cleanup

    }
}
