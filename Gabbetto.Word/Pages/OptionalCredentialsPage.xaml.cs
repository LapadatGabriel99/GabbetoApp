using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Fasseto.Word.Core;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for OptionalCredentialsPage.xaml
    /// </summary>
    public partial class OptionalCredentialsPage : BasePage<OptionalCredentialsViewModel>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public OptionalCredentialsPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="viewModel">The specific view model of this page</param>
        public OptionalCredentialsPage(OptionalCredentialsViewModel viewModel) : base(specificViewModel: viewModel)
        {
            InitializeComponent();
        }
    }
}
