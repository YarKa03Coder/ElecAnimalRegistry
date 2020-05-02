using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationOOP
{
    public interface INotify
    {
        void NotifyPropertyChanged(string propertyName);
    }
}
