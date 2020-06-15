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
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FriendRequestListItemControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The mouse enter event handler for the accept button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void accept_MouseEnter(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo(ColorType.WordDarkGreen.ToStringRGB());
        }

        /// <summary>
        /// The mouse leave event handler for the accept button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void accept_MouseLeave(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo(ColorType.WordGreen.ToStringRGB());
        }

        /// <summary>
        /// The mouse enter event handler for the decline button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void decline_MouseEnter(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo(ColorType.WordDarkRed.ToStringRGB());
        }

        /// <summary>
        /// The mouse leave event handler for the decline button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void decline_MouseLeave(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo(ColorType.WordRed.ToStringRGB());
        }
    }
}
