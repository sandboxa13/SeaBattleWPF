using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SeaBattleWPF.Core.Commands
{
    public class RelayCommand : ICommand
    {
        #region Private Members

        private readonly Func<Task> _task;

        private bool _canExecute = true;

        #endregion

        #region Public Members

        public RelayCommand(Func<Task> task) => _task = task;

        public RelayCommand(Action action) => _task = () =>
        {
            action.Invoke();
            return Task.CompletedTask;
        };

        public bool CanExecute(object parameter) => _canExecute;

        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {
            try
            {
                UpdateCanExecute(false);
                await _task.Invoke();
                UpdateCanExecute(true);
            }
            catch(Exception ex)
            {
                
            }
            void UpdateCanExecute(bool value)
            {
                _canExecute = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
