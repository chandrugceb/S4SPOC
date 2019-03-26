using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ShrackForStudents.Base
{
    public abstract class BaseViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool isBusy = false;
        private string _vmException;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;

                    OnPropertyChanged("IsBusy");
                }
            }
        }

        public string VmException
        {
            get => _vmException;
            set
            {
                if (value != null)
                {
                    _vmException = value;
                }
            }
        }

    }
}
