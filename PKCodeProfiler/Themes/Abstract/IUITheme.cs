using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PKCodeProfiler.Themes.Abstract
{
    public interface IUITheme
    {
        void Apply(Button control);
        void Apply(TextBox control);
        void Apply(DateTimePicker control);
        void Apply(Label control);
        void Apply(ComboBox control);
    }
}
