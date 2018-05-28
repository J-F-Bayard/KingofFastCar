using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DesignPatterns.MVVM.Commands
{
    public class RelayCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        readonly Func<bool> _CanExecute;
        readonly Action _Execute;

        public RelayCommand(Action Execute)
            : this(Execute, null)
        { }

        public RelayCommand(Action Execute, Func<bool> CanExecute)
        {
            if (Execute == null)
                throw new ArgumentNullException(nameof(Execute));
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute == null ? true : _CanExecute();
        }

        public void Execute(object parameter)
        {
            _Execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
