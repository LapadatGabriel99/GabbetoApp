﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    /// Interaction logic for TextEntryControl.xaml
    /// </summary>
    public partial class TextEntryControl : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// The label width of the control
        /// </summary>
        public GridLength LabelWidth
        {
            get { return (GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth",
                                         typeof(GridLength),
                                         typeof(TextEntryControl),
                                         new PropertyMetadata(GridLength.Auto, new PropertyChangedCallback(LabelWidthChangedCallback)));

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TextEntryControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Callbacks

        /// <summary>
        /// Called when the label length has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void LabelWidthChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                //Get the new length
                var gridLength = e.NewValue;

                //Set the column definition width to the new value

                (sender as TextEntryControl).LabelColumnDefinition.Width = ((GridLength)gridLength);
            }
            catch
            {
                //Make developer aware of potential issue
                Debugger.Break();

                (sender as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        #endregion
    }
}
