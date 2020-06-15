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

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for FriendRequestListItemControl.xaml
    /// </summary>
    public partial class FriendRequestListItemControl : UserControl
    {
        public FriendRequestListItemControl()
        {
            InitializeComponent();
        }

        private async void accept_MouseEnter(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo("");
        }

        private async void accept_MouseLeave(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo("");
        }

        private async void decline_MouseEnter(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo("");
        }

        private async void decline_MouseLeave(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo("");
        }
    }
}
