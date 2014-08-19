using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKCodeProfiler.Themes.Abstract;
using System.Windows.Forms;

namespace PKCodeProfiler.Mixins
{
    public static class UIMixins
    {
        static Dictionary<Type, Action<Control, IUITheme>> ThemeMap = new Dictionary<Type, Action<Control, IUITheme>>();
        static UIMixins()
        {
            ThemeMap.Add(typeof(Button), (control, theme) =>
            {
                theme.Apply(control as Button);
            });
            ThemeMap.Add(typeof(TextBox), (control, theme) =>
            {
                theme.Apply(control as TextBox);
            });
            ThemeMap.Add(typeof(DateTimePicker), (control, theme) =>
            {
                theme.Apply(control as DateTimePicker);
            });
            ThemeMap.Add(typeof(Label), (control, theme) =>
            {
                theme.Apply(control as Label);
            });
            ThemeMap.Add(typeof(ComboBox), (control, theme) =>
            {
                theme.Apply(control as ComboBox);
            });
        }

        public static void Accept(this Control control, IUITheme theme)
        {
            if (control != null)
            {
                if (ThemeMap.ContainsKey(control.GetType()))
                {
                    ThemeMap[control.GetType()](control, theme);
                }
                if (control.Controls != null)
                {
                    foreach (Control c in control.Controls)
                    {
                        c.Accept(theme);
                    }
                }
            }
        }
    }
}
