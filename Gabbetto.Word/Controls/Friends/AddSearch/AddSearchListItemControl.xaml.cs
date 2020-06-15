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
    /// Interaction logic for AddSearchListItemControl.xaml
    /// </summary>
    public partial class AddSearchListItemControl : UserControl
    {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AddSearchListItemControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The mouse enter event handler for the add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void add_MouseEnter(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo(ColorType.WordDarkBlue.ToStringRGB());
        }

        /// <summary>
        /// The mouse leave event handler for the add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void add_MouseLeave(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo(ColorType.WordBlue.ToStringRGB());
        }
    }
}
