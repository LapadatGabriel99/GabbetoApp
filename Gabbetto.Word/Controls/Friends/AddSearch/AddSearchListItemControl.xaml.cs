﻿using System;
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
    /// Interaction logic for AddSearchListItemControl.xaml
    /// </summary>
    public partial class AddSearchListItemControl : UserControl
    {
        public AddSearchListItemControl()
        {
            InitializeComponent();
        }

        private async void add_MouseEnter(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo("");
        }

        private async void add_MouseLeave(object sender, MouseEventArgs e)
        {
            // Perform the color change animation
            await this.ChangeColorTo("");
        }
    }
}
