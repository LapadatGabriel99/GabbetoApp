using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasseto.Word
{
    //public class PasswordBoxProperties
    //{

    //    public static readonly DependencyProperty MonitorPasswordProperty =
    //        DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false, OnMonitorPasswordChanged));

    //    //This event fires off when we set the monitorPassword dp a value
    //    private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    {
    //        var passwordBox = d as PasswordBox;

    //        if (passwordBox == null)
    //            return;

    //        //We clear of the previous event
    //        passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

    //        if ((bool)e.NewValue)
    //        {
    //            SetHasText(passwordBox);
    //            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
    //        }
    //    }

    //    private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    //    {
    //        //Every time we change passwordBox's password we fire of this event
    //        SetHasText((PasswordBox)sender);
    //    }

    //    public static void SetMonitorPassword(PasswordBox element, bool value)
    //    {
    //        element.SetValue(MonitorPasswordProperty, value);
    //    }

    //    public static bool GetMonitorPassword(PasswordBox element)
    //    {
    //        return (bool)element.GetValue(MonitorPasswordProperty);
    //    }

    //    public static readonly DependencyProperty HasTextProperty = 
    //        DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false));

    //    private static void SetHasText(PasswordBox element)
    //    {
    //        //Here we attach the dependency property itself, aswell as the value it comes with
    //        //If password.length > 0 => there is some text
    //        element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
    //    }

    //    public static bool GetHasText(PasswordBox element)
    //    {
    //        return (bool)element.GetValue(HasTextProperty);
    //    }
    //
    //}

    /// <summary>
    /// The MonitorPassword attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Retrieves the sender
            var passwordBox = sender as PasswordBox;

            //If null then return
            if (passwordBox == null)
                return;

            //Remove any previous listeners
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            //if the new-value equals true....
            if ((bool)e.NewValue)
            {
                //We set the the has textProperty with a new value
                HasTextProperty.SetValue(passwordBox);

                //Then we add a listener
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Set the has text property, passing the sender as a password box object
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// The HasText attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        //This can be reffered as a helper method
        //Instead of passing both the value and the sender
        //we pass just the sender
        public static void SetValue(DependencyObject sender)
        {
            //Call to the "original" setValue method
            //passing the value as well
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
