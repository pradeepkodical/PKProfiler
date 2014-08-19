using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace CodeProfiler.Tree.View
{
    internal abstract class RoundedRectangle
    {
        public enum RectangleCorners
        {
            None,
            TopLeft,
            TopRight,
            BottomLeft = 4,
            BottomRight = 8,
            All = 15
        }
        public static GraphicsPath Create(int x, int y, int width, int height, int radius, RoundedRectangle.RectangleCorners corners)
        {
            int num = x + width;
            int num2 = y + height;
            int num3 = num - radius;
            int num4 = num2 - radius;
            int num5 = x + radius;
            int num6 = y + radius;
            int num7 = radius * 2;
            int x2 = num - num7;
            int y2 = num2 - num7;
            var graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            if ((RoundedRectangle.RectangleCorners.TopLeft & corners) == RoundedRectangle.RectangleCorners.TopLeft)
            {
                graphicsPath.AddArc(x, y, num7, num7, 180f, 90f);
            }
            else
            {
                graphicsPath.AddLine(x, num6, x, y);
                graphicsPath.AddLine(x, y, num5, y);
            }
            graphicsPath.AddLine(num5, y, num3, y);
            if ((RoundedRectangle.RectangleCorners.TopRight & corners) == RoundedRectangle.RectangleCorners.TopRight)
            {
                graphicsPath.AddArc(x2, y, num7, num7, 270f, 90f);
            }
            else
            {
                graphicsPath.AddLine(num3, y, num, y);
                graphicsPath.AddLine(num, y, num, num6);
            }
            graphicsPath.AddLine(num, num6, num, num4);
            if ((RoundedRectangle.RectangleCorners.BottomRight & corners) == RoundedRectangle.RectangleCorners.BottomRight)
            {
                graphicsPath.AddArc(x2, y2, num7, num7, 0f, 90f);
            }
            else
            {
                graphicsPath.AddLine(num, num4, num, num2);
                graphicsPath.AddLine(num, num2, num3, num2);
            }
            graphicsPath.AddLine(num3, num2, num5, num2);
            if ((RoundedRectangle.RectangleCorners.BottomLeft & corners) == RoundedRectangle.RectangleCorners.BottomLeft)
            {
                graphicsPath.AddArc(x, y2, num7, num7, 90f, 90f);
            }
            else
            {
                graphicsPath.AddLine(num5, num2, x, num2);
                graphicsPath.AddLine(x, num2, x, num4);
            }
            graphicsPath.AddLine(x, num4, x, num6);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }
        public static GraphicsPath Create(Rectangle rect, int radius, RoundedRectangle.RectangleCorners c)
        {
            return RoundedRectangle.Create(rect.X, rect.Y, rect.Width, rect.Height, radius, c);
        }
        public static GraphicsPath Create(int x, int y, int width, int height, int radius)
        {
            return RoundedRectangle.Create(x, y, width, height, radius, RoundedRectangle.RectangleCorners.All);
        }
        public static GraphicsPath Create(Rectangle rect, int radius)
        {
            return RoundedRectangle.Create(rect.X, rect.Y, rect.Width, rect.Height, radius);
        }
        public static GraphicsPath Create(int x, int y, int width, int height)
        {
            return RoundedRectangle.Create(x, y, width, height, 5);
        }
        public static GraphicsPath Create(Rectangle rect)
        {
            return RoundedRectangle.Create(rect.X, rect.Y, rect.Width, rect.Height);
        }        
    }
}
