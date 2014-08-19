using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PKCodeProfiler.Themes.Abstract;
using PKCodeProfiler.Mixins;

namespace PKCodeProfiler.Views.Abstract
{
    public partial class BaseChildView : UserControl, IChildView
    {
        public event Action OnToggleFullScreen;
        public BaseChildView()
        {
            InitializeComponent();
        }

        #region IChildView Members
        public event Action<string> OnSetMessage;
        public event Action<IChildView> Close;

        private IUITheme theme;
        public IUITheme Theme
        {
            set
            {
                if (theme != value)
                {
                    theme = value;
                    this.OnThemeChanged();
                }
            }
            protected get
            {
                return theme;
            }
        }

        protected void SetMessage(string message)
        {
            if (OnSetMessage != null)
            {
                OnSetMessage(message);
            }
        }

        private void OnThemeChanged()
        {
            foreach (Control c in this.Controls)
            {
                c.Accept(theme);
            }
        }

        public BaseChildView ChildControl
        {
            get { return this; }
        }

        private string _TabHeader;
        public string TabHeader
        {
            get
            {
                return _TabHeader;
            }
            set
            {
                _TabHeader = value;
                lblBaseTitle.Text = _TabHeader;
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Close != null)
            {
                this.Close(this);
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            if (OnToggleFullScreen != null)
            {
                OnToggleFullScreen();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(241, 196, 15);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(192, 57, 43);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(231, 76, 60);
        }
    }
}
