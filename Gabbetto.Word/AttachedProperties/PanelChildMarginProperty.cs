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
    /// The PanelChildMarginProperty attached property for creating a <see cref="Panel"/> that has 
    /// and keeps the navigation history empty
    /// </summary>
    public class PanelChildMarginProperty : BaseAttachedProperty<PanelChildMarginProperty, string>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get the panel 
            var panel = sender as Panel;

            //Wait for panel to load
            panel.Loaded += (ss, ee) =>
            {
                //Loop each child
                foreach (FrameworkElement child in panel.Children)
                {
                    //Set it's margin to the given value
                    child.Margin = (Thickness)(new ThicknessConverter().ConvertFromString(e.NewValue as string));
                }
            };
        }

    }
}
