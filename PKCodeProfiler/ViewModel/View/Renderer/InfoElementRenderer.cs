using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CodeProfiler.Tree.ViewModel;

namespace CodeProfiler.Tree.View.Renderer
{
    internal class InfoElementRenderer : ElementRenderer
    {
        private readonly int INFO_WIDTH = 80;
        private readonly int INFO_HEIGHT = 20;

        public InfoElementRenderer(TreeNodeViewModel model, Font font)
            : base(model)
        {
            this.Font = font;
        }
        public override void Render(Graphics graphics, Rectangle rect)
        {
            using (var font = new Font("Verdana", 8))
            {
                var ellipseRect = GetRect(rect);
                var path = RoundedRectangle.Create(ellipseRect, 5, 
                    RoundedRectangle.RectangleCorners.TopRight |
                    RoundedRectangle.RectangleCorners.BottomRight);
                using (var brush = new SolidBrush(GetBrushColor()))
                {
                    graphics.FillPath(brush, path);
                    RenderTextCenter(graphics, Brushes.White, ellipseRect, font, 
                        this.Model.TraceNode.TimeTaken);
                    using (var pen = new Pen(GetPenColor(), 1))
                    {
                        graphics.DrawPath(pen, path);
                    }
                }
            }
        }

        private Rectangle GetRect(Rectangle rect)
        {
            var ellipseRect = new Rectangle(
                rect.X + rect.Width - 6, 
                rect.Y + (rect.Height - INFO_HEIGHT)/2, 
                INFO_WIDTH, 
                INFO_HEIGHT);

            if (this.Model.IsSelected) 
            {
                ellipseRect.X += 3;
            }
            return ellipseRect;
        }

        private Color GetPenColor()
        {
            if (this.Model.TraceNode.TimeTakenMilliseconds > this.Model.ThresholdMilliseconds)
            {
                return Color.FromArgb(192, 57, 43);
            }
            else
            {
                return Color.FromArgb(243, 156, 18);
            }
        }

        private Color GetBrushColor()
        {
            if (this.Model.TraceNode.TimeTakenMilliseconds > this.Model.ThresholdMilliseconds)
            {
                return Color.FromArgb(231, 76, 60);                
            }
            else
            {
                return Color.FromArgb(241, 196, 15);                
            }
        }
    }
}
