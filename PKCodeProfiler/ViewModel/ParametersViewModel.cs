using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using PKCodeWeaver.Framework.Model;

namespace PKCodeProfiler.ViewModel
{
    public class ParametersViewModel : 
        IWeaveParameters, 
        INotifyPropertyChanged
    {
        public ParametersViewModel()
        {
            this.IncludeClasses = new List<string>();
            this.PropertyChanged -= new PropertyChangedEventHandler(ParametersViewModel_PropertyChanged);
            this.PropertyChanged += new PropertyChangedEventHandler(ParametersViewModel_PropertyChanged);
        }

        public void Clear()
        {
            this.IISReset = false;
            this.DecodeParameters = false;
            this.FileName = string.Empty;
            this.AssemblySignKeyFile = string.Empty;
            this.IncludeClasses.Clear();
            this.IsFileSelected = false;            
        }

        void ParametersViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AssemblySignKeyFile")
            {
                this.IISReset = !String.IsNullOrEmpty(this.AssemblySignKeyFile);
            }
        }

        private List<string> _IncludeClasses;
        public List<string> IncludeClasses
        {
            get
            {
                return _IncludeClasses;
            }
            set
            {
                if (_IncludeClasses != value)
                {
                    _IncludeClasses = value;
                    this.RaisePropertyChange("IncludeClasses");
                }
            }
        }

        private string _AssemblySignKeyFile;
        public string AssemblySignKeyFile
        {
            get
            {
                return _AssemblySignKeyFile;
            }
            set
            {
                if (_AssemblySignKeyFile != value)
                {
                    _AssemblySignKeyFile = value;
                    this.RaisePropertyChange("AssemblySignKeyFile");
                }
            }
        }

        private string _FileName;
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                if (_FileName != value)
                {
                    _FileName = value;
                    this.RaisePropertyChange("FileName");
                    this.IsFileSelected = (value != null || value != string.Empty);                    
                }
            }
        }

        private bool _IsFileSelected;
        public bool IsFileSelected
        {
            get
            {
                return _IsFileSelected;
            }
            set
            {
                if (_IsFileSelected != value)
                {
                    _IsFileSelected = value;
                    this.RaisePropertyChange("IsFileSelected");
                }
            }
        }

        private bool _DecodeParameters;
        public bool DecodeParameters 
        {
            get
            {
                return _DecodeParameters;
            }
            set
            {
                if (_DecodeParameters != value)
                {
                    _DecodeParameters = value;
                    this.RaisePropertyChange("DecodeParameters");
                }
            }
        }

        private bool _IISReset;
        public bool IISReset
        {
            get
            {
                return _IISReset;
            }
            set
            {
                if (_IISReset != value)
                {
                    _IISReset = value;
                    this.RaisePropertyChange("IISReset");
                }
            }
        }
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChange(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion
    }
}
