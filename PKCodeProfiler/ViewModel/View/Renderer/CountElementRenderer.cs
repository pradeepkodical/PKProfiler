using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CodeProfiler.Tree.ViewModel;

namespace CodeProfiler.Tree.View.Renderer
{
    internal class CountElementRenderer: ElementRenderer
    {
        private readonly int COUNT_WIDTH = 20;
        private readonly int COUNT_HEIGHT = 16;

        public CountElementRenderer(TreeNodeViewModel model, Font font)
            : base(model)
        {
            this.Font = font;
        }
        public override void Render(Graphics graphics, Rectangle rect)
        {
            if (Model.Children.Count > 0)
            {                
                var ellipseRect = GetRect(rect);
                var path = RoundedRectangle.Create(ellipseRect, 8);
                using (var brush = new SolidBrush(GetBrushColor()))
                {
                    graphics.FillPath(brush, path);
                    RenderTextCenter(graphics, Brushes.Black, ellipseRect, this.Font, Model.Children.Count.ToString());
                    using (var pen = new Pen(GetPenColor(), 2))
                    {
                        graphics.DrawPath(pen, path);
                    }
                }                
            }
        }

        private Rectangle GetRect(Rectangle rect)
        {
            return new Rectangle(
                rect.X - 2,
                rect.Y + (rect.Height - COUNT_HEIGHT)/2,
                COUNT_WIDTH, COUNT_HEIGHT);
        }

        private Color GetPenColor()
        {
            return Color.FromArgb(41, 128, 185);
        }

        private Color GetBrushColor()
        {
            return Color.FromArgb(236, 240, 241);
        }
    }
}
