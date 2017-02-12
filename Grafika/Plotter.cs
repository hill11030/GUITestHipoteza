using FGV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika
{
    public class Plotter
    {
        private Graphics canvas;
        private Brush backgroundColor;
        private Rectangle area;
        private CoordinateSystem cSystem;

        public Plotter(Graphics canvas, Brush backgroundColor, Rectangle area, CoordinateSystem cSystem)
        {
            this.canvas = canvas;
            this.backgroundColor = backgroundColor;
            this.area = area;
            this.cSystem = cSystem;
        }

        public void DrawCoordinateSystem(Pen color)
        {
            // 23.10.2016
            // dodati brojeve za podelu po X i Y osi (ili skalirati velicinu fonta ili povecati offset-e ili  sta Sava smisli)

            int offsetX = 40;
            int offsetY = 40;
            double segmentWidth = (area.Width - offsetX) / (cSystem.NumXPoints + 1);
            double segmentHeight = (area.Height - offsetY) / (cSystem.NumYPoints + 1);
            int notchDimension = 3;

            Rectangle graphArea = new Rectangle(new Point(area.Location.X + offsetX, area.Y), new Size(area.Width - offsetX, area.Height - offsetY));

            canvas.FillRectangle(backgroundColor, graphArea);
            canvas.DrawRectangle(color, graphArea);

            Font font = new Font(FontFamily.GenericSerif, 7);
            canvas.DrawString(cSystem.XMin.ToString("00.00"), font, color.Brush, area.X + offsetX - (float)Math.Round(canvas.MeasureString(cSystem.XMin.ToString("00.00"), font).Width / 2), area.Y + area.Height - offsetY + 3);
            canvas.DrawString(cSystem.XMax.ToString("00.00"), font, color.Brush, area.X + area.Width - (float)Math.Round(canvas.MeasureString(cSystem.XMax.ToString("00.00"), font).Width / 2), area.Y + area.Height - offsetY + 3);
            for (int i = 0; i < cSystem.NumXPoints; i ++)
            {
                canvas.DrawLine(color, (int)Math.Round(graphArea.X + (i + 1) * segmentWidth, 0), graphArea.Y, (int)Math.Round(graphArea.X + (i + 1) * segmentWidth, 0), graphArea.Y + notchDimension);
                canvas.DrawLine(color, (int)Math.Round(graphArea.X + (i + 1) * segmentWidth, 0), graphArea.Y + graphArea.Height, (int)Math.Round(graphArea.X + (i + 1) * segmentWidth, 0), graphArea.Y + graphArea.Height - notchDimension);
            }

            canvas.DrawString(cSystem.YMin.ToString("00.00"), font, color.Brush, area.X, area.Y + area.Height - offsetY - (float)Math.Round(canvas.MeasureString(cSystem.YMin.ToString("00.00"), font).Height / 2));
            canvas.DrawString(cSystem.YMax.ToString("00.00"), font, color.Brush, area.X, area.Y - (float)Math.Round(canvas.MeasureString(cSystem.YMax.ToString("00.00"), font).Height / 2));
            for (int i = 0; i < cSystem.NumYPoints; i++)
            {
                canvas.DrawLine(color, graphArea.X, (int)Math.Round(graphArea.Y + (i + 1) * segmentHeight, 0), graphArea.X + notchDimension, (int)Math.Round(graphArea.Y + (i + 1) * segmentHeight, 0));
                canvas.DrawLine(color, graphArea.X + graphArea.Width, (int)Math.Round(graphArea.Y + (i + 1) * segmentHeight, 0), graphArea.X + graphArea.Width - notchDimension, (int)Math.Round(graphArea.Y + (i + 1) * segmentHeight, 0));
            }

            //canvas.TranslateTransform((float)(cSystem.XMax - cSystem.XMin), (float)(cSystem.YMax - cSystem.YMin));
            //canvas.ScaleTransform((float)cSystem.NumXPoints, (float)cSystem.NumYPoints);
        }

        public void DrawPoints(Point[] points)
        {
            canvas.TranslateTransform(500, 150);
            foreach (var point in points)
            {
                canvas.DrawRectangle(Pens.Blue, point.X, point.Y, 3, 3);
                //canvas.DrawEllipse(Pens.Green, points[0].X, points[0].Y, 3, 3);
            }
        }

        public void DrawFunction(TemplateFunction function)
        {
            double segmentWidth = (cSystem.XMax - cSystem.XMin) / (cSystem.NumXPoints + 1);
            for (double x = cSystem.XMin; x <= cSystem.XMax; x = x + segmentWidth)
            {
                if (function.GetValue(x) * function.GetValue(x+segmentWidth) <= 0)
                {
                    canvas.DrawRectangle(Pens.Green, (int)x, (int)function.GetValue(x), 3, 3);
                }
            }
        }

    }
}
