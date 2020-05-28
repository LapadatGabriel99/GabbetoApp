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
    /// Interaction logic for ChatListControl.xaml
    /// </summary>
    public partial class ChatListControl : SideMenuBasePage<ChatListViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatListControl() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="viewModel">The view model of this page</param>
        public ChatListControl(ChatListViewModel viewModel) : base(specificViewModel: viewModel)
        {
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        public async override void OnViewModelChanged()
        {
            // Perform a fade in animation
            await this.FadeInAsync();
        }

        #endregion
    }
}
