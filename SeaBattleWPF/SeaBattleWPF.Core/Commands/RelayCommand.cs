using System;
using System.Windows.Input;

namespace SeaBattleWPF.Core.ViewModels
{
    public class RelayCommand : ICommand
    {
        #region Private Members

        private readonly Action _mAction;
            
        #endregion

        #region Public events

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Conctructor
        public RelayCommand(Action action)
        {
            _mAction = action;
        }

        #endregion

        #region Command methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mAction();
        }

        #endregion
    }
}
