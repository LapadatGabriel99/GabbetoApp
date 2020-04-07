﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The view model for the register page
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        #region Private Members       

        #endregion

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating whether we are trying to register or not
        /// </summary>
        public bool RegisterIsRunning { get; set; } = false;

        #endregion

        #region Commands

        /// <summary>
        /// The command to go to the login page
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to perform registration action
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RegisterViewModel()
        {
            //Create commands
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// Takes the user to the login page
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }

        /// <summary>
        /// Attempts to register the user
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the user's password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            await RunCommandAsync(() => this.RegisterIsRunning, async () => 
            {
                await Task.Delay(5000);

                var email = this.Email;

                var securePassword = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }

        #endregion

    }
}