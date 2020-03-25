using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace Fasseto.Word
{
    /// <summary>
    /// Focuses (keyboard focus) this element on load
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //If we don't have a control, return
            if (!(sender is Control control))
                return;

            //Focus this control once loaded
            control.Loaded += (ss, ee) => control.Focus();
        }
    }

    /// <summary>
    /// Focuses (keyboard focus) this element if true
    /// </summary>
    public class FocusProperty : BaseAttachedProperty<FocusProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is TextBoxBase text)
            {
                if ((bool)e.NewValue)
                    //Focus this control
                    text.Focus();
            }

            if (sender is PasswordBox password)
            {
                if ((bool)e.NewValue)
                    //Focus this control
                    password.Focus();
            }
        }
    }

    /// <summary>
    /// Focuses (keyboard focus) and selects all text in this element if true
    /// </summary>
    public class FocusAndSelectProperty : BaseAttachedProperty<FocusAndSelectProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is TextBoxBase text)
            {
                if ((bool)e.NewValue)
                {
                    //Focus this control
                    text.Focus();

                    //Select text
                    text.SelectAll();
                }
            }

            if (sender is PasswordBox password)
            {
                if ((bool)e.NewValue)
                {
                    //Focus this control
                    password.Focus();

                    //Select text
                    password.SelectAll();
                }
            }
        }
    }

    /// <summary>
    /// Focuses (keyboard focus) this element if true
    /// </summary>
    public class SelectProperty : BaseAttachedProperty<SelectProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is TextBoxBase text)
            {
                if ((bool)e.NewValue)
                    //Select this control
                    text.SelectAll();
            }

            if (sender is PasswordBox password)
            {
                if ((bool)e.NewValue)
                    //Select this control
                    password.SelectAll();
            }
        }
    }
}
