using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Fasseto.Word
{
    ///<sumary>
    ///Scroll an items control to the bottom when the data context changes
    ///</sumary>
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            if (!(sender is ScrollViewer control))
                return;

            //Scroll content to bottom when context changes
            control.DataContextChanged -= Control_DataContextChanged;
            control.DataContextChanged += Control_DataContextChanged;
        }

        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((ScrollViewer)sender).ScrollToBottom();
        }
    }

    /// <summary>
    /// Automatically keep the scroll at the bottom of the screen we already are close to bottom
    /// </summary>
    public class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is ScrollViewer scrollViewer))
                return;

            //Scroll content to bottom when new content get's added in
            scrollViewer.ScrollChanged -= ScrollViewer_ScrollChanged;
            scrollViewer.ScrollChanged += ScrollViewer_ScrollChanged;
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;

            //If we are very close to the bottom
            if (scrollViewer.ScrollableHeight - scrollViewer.VerticalOffset < 20)
                scrollViewer.ScrollToBottom();
        }
    }
}
