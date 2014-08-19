using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PKCodeProfiler.ViewModel
{
    public class TraceGroupViewModel : 
        INotifyPropertyChanged
    {
        public TraceGroupViewModel()
        {
            this.IsNotRunning = true;
        }
        private string _GroupKey;
        public string GroupKey
        {
            get
            {
                return _GroupKey;
            }
            set
            {
                if (_GroupKey != value)
                {
                    _GroupKey = value;
                    RaisePropertyChanged("GroupKey");
                }
            }
        }

        private int _ThresholdMilliseconds;
        public int ThresholdMilliseconds
        {
            get
            {
                return _ThresholdMilliseconds;
            }
            set
            {
                if (_ThresholdMilliseconds != value)
                {
                    _ThresholdMilliseconds = value;
                    this.RaisePropertyChanged("ThresholdMilliseconds");
                }
            }
        }

        private bool _IsNotRunning;
        public bool IsNotRunning
        {
            get
            {
                return _IsNotRunning;
            }
            set
            {
                if (_IsNotRunning != value)
                {
                    _IsNotRunning = value;
                    this.RaisePropertyChanged("IsNotRunning");
                }
            }
        }
    

        private void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        private DateTime _StartDate;
        private DateTime _EndDate;
        public DateTime StartDate 
        {
            get
            {
                return _StartDate;
            }
            set
            {
                if (_StartDate != value)
                {
                    _StartDate = value;
                    this.RaisePropertyChanged("StartDate");
                }
            }
        }

        public DateTime EndDate 
        {
            get
            {
                return _EndDate;
            }
            set
            {
                if (_EndDate != value)
                {
                    _EndDate = value;
                    this.RaisePropertyChanged("EndDate");
                }
            }
        }

        private string _UserKey;
        public string UserKey
        {
            get
            {
                return _UserKey;
            }
            set
            {
                if (_UserKey != value)
                {
                    _UserKey = value;
                    this.RaisePropertyChanged("UserKey");
                }
            }
        }

        private string _HostName;
        public string HostName
        {
            get
            {
                return _HostName;
            }
            set
            {
                if (_HostName != value)
                {
                    _HostName = value;
                    this.RaisePropertyChanged("HostName");
                }
            }
        }
    

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
