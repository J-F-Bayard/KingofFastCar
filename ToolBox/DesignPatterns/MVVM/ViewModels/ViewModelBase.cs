using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DesignPatterns.MVVM.Commands;

namespace ToolBox.DesignPatterns.MVVM.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private Action _CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public ViewModelBase()
        {
            Type TViewModel = GetType();
            foreach (PropertyInfo pi in TViewModel.GetProperties())
            {
                if (pi.PropertyType == typeof(ICommand) || pi.PropertyType.GetInterfaces().Contains(typeof(ICommand)))
                {
                    ICommand cmd = (ICommand)pi.GetMethod.Invoke(this, null);
                    _CanExecuteChanged += cmd.RaiseCanExecuteChanged;
                }
            }
            if (_CanExecuteChanged != null)
                PropertyChanged += (sender, e) => RaiseCanExecuteChanged();
        }
        protected void RaiseCanExecuteChanged()
        {
            _CanExecuteChanged?.Invoke();
        }
    }
}
