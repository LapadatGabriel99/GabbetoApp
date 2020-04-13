using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginPage() : base()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public LoginPage(LoginViewModel viewModel) : base(specificViewModel: viewModel)
        {
            InitializeComponent();
        }

        #endregion

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
