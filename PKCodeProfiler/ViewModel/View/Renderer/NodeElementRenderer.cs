using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CodeProfiler.Tree.ViewModel;

namespace CodeProfiler.Tree.View.Renderer
{
    internal class NodeElementRenderer: ElementRenderer
    {
        public NodeElementRenderer(TreeNodeViewModel model, Font font)
            : base(model)
        {
            this.Font = font;
        }
        public override void Render(Graphics graphics, Rectangle rect)
        {
            var path = RoundedRectangle.Create(rect, 1);
            using (var brush = new SolidBrush(GetBrushColor()))
            {
                graphics.FillPath(brush, path);                    
            }
            using (var pen = new Pen(GetPenColor(), 2))
            {
                graphics.DrawPath(pen, path);
            }

            using (var brush = new SolidBrush(GetTextBrushColor()))
            {
                RenderTextCenter(graphics, brush, rect, this.Font, Model.Text);
            }
        }

        private Color GetTextBrushColor()
        {
            if (Model.IsSelected)
            {
                return Color.FromArgb(192, 57, 43);
            }
            else
            {
                return Color.FromArgb(236, 240, 241);
            }
        }

        private Color GetPenColor()
        {
            if (Model.IsSelected)
            {
                return Color.FromArgb(192, 57, 43);
            }
            else
            {
                return Color.FromArgb(236, 240, 241);
            }
        }

        private Color GetBrushColor()
        {
            if (Model.IsSelected)
            {
                return Color.FromArgb(241, 196, 15);
            }
            else
            {
                return Color.FromArgb(26, 188, 156);
            }
        }
    }
}
