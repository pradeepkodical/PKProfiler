using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CodeProfiler.Tree.ViewModel;

namespace CodeProfiler.Tree.View.Renderer
{
    internal abstract class ElementRenderer
    {
        public Font Font { get; protected set; }
        public TreeNodeViewModel Model { get; set; }
        public ElementRenderer(TreeNodeViewModel model)
        {
            this.Model = model;
        }
        public abstract void Render(Graphics graphics, Rectangle rect);

        protected void RenderTextCenter(Graphics graphics, Brush brush, Rectangle rect, Font font, string text)
        {
            var box = graphics.MeasureString(text, font);
            var point = new PointF(rect.X + (rect.Width - box.Width) / 2, rect.Y + (rect.Height - box.Height) / 2);
            graphics.DrawString(text, font, brush, point);
        }

        protected void RenderTextLeft(Graphics graphics, Brush brush, Rectangle rect, Font font, string text)
        {
            var box = graphics.MeasureString(text, font);
            var point = new PointF(rect.X + 10, rect.Y + (rect.Height - box.Height) / 2);
            graphics.DrawString(text, font, brush, point);
        }
    }
}
