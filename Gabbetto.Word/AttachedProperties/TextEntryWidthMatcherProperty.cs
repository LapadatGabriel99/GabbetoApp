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
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get the panel 
            var panel = (sender as Panel);

            //Call SetWidths initially
            SetWidths(panel);

            //Wait for panel to load
            RoutedEventHandler onLoaded = null;
            onLoaded = (ss, ee) =>
            {
                //Unhook ourselves
                panel.Loaded -= onLoaded;

                //Set widths
                SetWidths(panel);

                //Loop every child
                foreach (var child in panel.Children)
                {
                    //Ignore all non-text entry control items
                    if (!(child is TextEntryControl) || !(child is PasswordEntryControl))
                        continue;

                    //Get the label from the text and password entry
                    var label = child is TextEntryControl ? (child as TextEntryControl).Label : (child as PasswordEntryControl).Label;

                    //Set the text entry control size
                    label.SizeChanged += (sss, eee) =>
                    {
                        //Update widths
                        SetWidths(panel);
                    };
                }
            };

            //Hook our loaded event with onLoaded handler
            panel.Loaded += onLoaded;
        }

        ///<summary>
        ///Update all child text entry controls so their widths match the largest width of the group
        ///</summary>
        ///<param name="panel">The panel cotaining the text entry controls</param>
        private void SetWidths(Panel panel)
        {
            var maxSize = 0d;

            //For each child
            foreach (var child in panel.Children)
            {
                //Ignore all non-text entry control items
                if (!(child is TextEntryControl) || !(child is PasswordEntryControl))
                    continue;

                //Get the label from the text and password entry
                var label = child is TextEntryControl ? (child as TextEntryControl).Label : (child as PasswordEntryControl).Label;

                //Find if this value is larger than other
                maxSize = Math.Max(maxSize, label.RenderSize.Width + label.Margin.Left + label.Margin.Right);
            }

            // Create a grid length converter
            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());

            foreach (var child in panel.Children)
            {
                if (child is TextEntryControl text)
                    text.LabelWidth = gridLength;

                else if (child is PasswordEntryControl password)
                    password.LabelWidth = gridLength;
            }
        }
    }
}
