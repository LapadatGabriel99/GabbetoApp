using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    public class RelayCommand : ICommand
    {

        #region Private Members


        /// <summary>
        /// action to run
        /// </summary>
        private Action _action;

        #endregion

        #region Public Commands
        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            _action = action;
        }

        #endregion

        #region Command Methods
        /// <summary>
        /// A relay command can always execute 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// This function decides if the button is available for use or not
        /// A relay command can always execute
        public bool CanExecute(object parameter) => true;
        
        /// <summary>
        /// Executes the command we passed in
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action();
        }

        #endregion
    }
}
