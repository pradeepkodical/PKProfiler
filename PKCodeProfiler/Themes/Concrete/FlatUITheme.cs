using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKCodeProfiler.Themes.Abstract;
using System.Windows.Forms;
using System.Drawing;

namespace PKCodeProfiler.Themes.Concrete
{
    public class FlatUITheme : IUITheme
    {
        #region IUITheme Members

        public void Apply(Button control)
        {
            control.FlatStyle = FlatStyle.Flat;
            //control.ForeColor = Color.FromArgb(236, 240, 241);
            //control.BackColor = Color.FromArgb(52, 73, 94);
            control.FlatAppearance.BorderColor = Color.FromArgb(22, 160, 133);
            control.FlatAppearance.BorderSize = 2;
            control.FlatAppearance.MouseDownBackColor = Color.FromArgb(241, 196, 15);
            control.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 188, 156);
            control.Cursor = Cursors.Hand;
        }

        public void Apply(TextBox control)
        {

        }

        public void Apply(DateTimePicker control)
        {

        }

        public void Apply(Label control)
        {
            //control.ForeColor = Color.FromArgb(52, 73, 94);
        }

        public void Apply(ComboBox control)
        {

        }

        #endregion
    }
}
