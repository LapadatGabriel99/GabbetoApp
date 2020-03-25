using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasseto.Word
{
    /// <summary>
    /// The NoFrameHistory attached property for creating a <see cref="Frame"/> that never shows navigation bar
    /// and keeps the navigation history empty
    /// </summary>
    public class NoFrameHistoryProperty : BaseAttachedProperty<NoFrameHistoryProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get the frame
            var frame = sender as Frame;

            //Hide navigation bar
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Clear history on navigate
            frame.Navigated += (ss, ee) => (ss as Frame).NavigationService.RemoveBackEntry();
        }
    }
}
