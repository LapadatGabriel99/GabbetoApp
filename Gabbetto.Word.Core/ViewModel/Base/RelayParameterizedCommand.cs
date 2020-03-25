using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    public class RelayParameterizedCommand : ICommand
    {

        #region Private Members

        private Action<object> _action;

        #endregion

        #region Public Events

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion


        #region Constructors

        /// <summary>
        /// Default Constructor with parameterized action
        /// </summary>
        /// <param name="action"></param>
        public RelayParameterizedCommand(Action<object> action)
        {
            _action = action;
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// A relay command always executes
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;
        
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action(parameter);
        }

        #endregion
    }
}
