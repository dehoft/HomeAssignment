using System;
using System.Windows.Input;

namespace TesonetHomeAssignment.ViewModel.Base
{
    /// <inheritdoc />
    /// <summary>
    /// A basic command that runs an Action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// The action to run
        /// </summary>
        private readonly Action _mAction;

        #endregion Private Members

        #region Public Events

        /// <inheritdoc />
        /// <summary>
        /// The event that's fired when the <see cref="M:SparrowFly.UI.ViewModel.Base.RelayCommand.CanExecute(System.Object)" /> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion Public Events

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            _mAction = action;
        }

        #endregion Constructor

        #region Command Methods

        /// <inheritdoc />
        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <inheritdoc />
        /// <summary>
        /// Executes the commands Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _mAction();
        }

        #endregion Command Methods
    }
}
