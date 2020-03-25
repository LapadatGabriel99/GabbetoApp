using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fasseto.Word
{
    ///<sumary>
    /// Creates a clipping region from the parent <see cref="Border"/> <see cref="CornerRadius"/>
    ///</sumary>
    public class ClipFromBorderProperty : BaseAttachedProperty<ClipFromBorderProperty, bool>
    {
        #region Private Members

        /// <summary>
        /// Called when the parent border first loads
        /// </summary>
        private RoutedEventHandler _border_loaded;

        /// <summary>
        /// Called when the parent border changes size
        /// </summary>
        private SizeChangedEventHandler _size_Changed;

        #endregion

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get self
            var self = sender as FrameworkElement;

            //Check we have a border as a parent
            if (!(self.Parent is Border border))
            {
                Debugger.Break();
                return;
            }

            //Setup loaded event
            _border_loaded = (s1, e1) => { Border_OnChange(s1, e1, self); };

            //Setup size changed event
            _size_Changed = (s2, e2) => { Border_OnChange(s2, e2, self); };

            //If true, hoot into events
            if ((bool)e.NewValue)
            {
                border.Loaded += _border_loaded;
                border.SizeChanged += _size_Changed;
            }
            //Otherwise, unhook
            else
            {
                border.Loaded -= _border_loaded;
                border.SizeChanged -= _size_Changed;
            }
        }

        /// <summary>
        /// Called when the border is loaded and changed sized
        /// </summary>
        /// <param name="sender">The border</param>
        /// <param name="e"></param>
        /// <param name="child">The child element ourselves</param>
        private void Border_OnChange(object sender, RoutedEventArgs e, FrameworkElement child)
        {
            //Get the border
            var border = sender as Border;

            //Check if we have an actual size
            if (border.ActualHeight == 0 && border.ActualWidth == 0)
                return;

            // Setup the new child clipping area
            var rectangle = new RectangleGeometry();

            //March the corner radius with the borders corner radius
            rectangle.RadiusX = rectangle.RadiusY = Math.Max(0, border.CornerRadius.TopLeft - (border.BorderThickness.Left * 0.5));

            //Set the rectangle size to match child's actual size
            rectangle.Rect = new Rect(child.RenderSize);

            //Assign clipping area to the child
            child.Clip = rectangle;
        }
    }
}
