using System;
using System.Windows.Input;

namespace ObjectInformation.Infrastructure.Commands
{
    public abstract class BaseCommand : ICommand
    {
        #region Events
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Methods
        public virtual bool CanExecute(object parameter) => true;
        public abstract void Execute(object parameter);

        protected void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, new EventArgs());
        #endregion
    }
}
