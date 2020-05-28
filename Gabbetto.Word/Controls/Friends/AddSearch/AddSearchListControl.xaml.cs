using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for AddSearchListControl.xaml
    /// </summary>
    public partial class AddSearchListControl : SideMenuBasePage<SearchAddListViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AddSearchListControl() : base()
        {
            InitializeComponent();
        } 

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public AddSearchListControl(SearchAddListViewModel viewModel) : base(specificViewModel: viewModel)
        {
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        public async override void OnViewModelChanged()
        {
            // Perform an fade in animation
            await this.FadeInAsync();
        }

        #endregion
    }
}
