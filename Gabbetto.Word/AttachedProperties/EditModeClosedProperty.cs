using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Fasseto.Word
{
    /// <summary>
    /// A property that indicates if we exited edit mode
    /// </summary>
    public class EditModeClosedProperty : BaseAttachedProperty<EditModeClosedProperty, bool>
    {
        public override void OnValueUpdated(DependencyObject sender, object e)
        {
            // If the new value is true            
            if((bool)e == true)
            {
                // Check if the sender is a password box
                if(sender is PasswordBox passwordBox)
                {
                    // Clear the content inside the password box
                    passwordBox.Clear();

                    // Return
                    return;
                }                     
            }
            // Otherwise return
            else
            {
                // Return
                return;
            }
        }        
    }
}
