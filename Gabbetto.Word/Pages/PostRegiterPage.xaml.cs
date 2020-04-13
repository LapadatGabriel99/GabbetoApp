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
    /// Interaction logic for PostRegiterPage.xaml
    /// </summary>
    public partial class PostRegiterPage : BasePage<PostRegisterViewModel>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PostRegiterPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        public PostRegiterPage(PostRegisterViewModel viewModel) : base(specificViewModel: viewModel)
        {
            InitializeComponent();
        }
    }
}
