using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;

namespace Fasseto.Word
{
    /// <summary>
    /// Framework element animation helpers in specific ways
    /// </summary>
    public static class FrameworkElementAnimationHelpers
    {
        #region SlideAndFadeIn

        /// <summary>
        /// Slides an element in from the right, plus the fade in effect
        /// </summary>
        /// <param name="frameworkElement">The element to animate</param>
        /// <param name="seconds">The time it will take to complete the animation</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="width">The animation width to animate to. If not specified the elements width is used.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement frameworkElement, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //Create the storyboard
            var storyboard = new Storyboard();

            //Add slide from right animation
            storyboard.AddSlideFromRight(seconds, width == 0 ? frameworkElement.ActualWidth : width, keepMargin: keepMargin);

            //Add fade in animation
            storyboard.AddFadeIn(seconds);

            //Begin the storyboard animation on the specific page we pass in
            storyboard.Begin(frameworkElement);

            //Make element visible only if we are animating

            frameworkElement.Visibility = Visibility.Visible;

            //Await for the animation to finish right on time
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element in from the left, plus the fade in effect
        /// </summary>
        /// <param name="frameworkElement">The element to animate</param>
        /// <param name="seconds">The time it will take to complete the animation</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="width">The animation width to animate to. If not specified the elements width is used.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement frameworkElement, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //Create the storyboard
            var storyboard = new Storyboard();

            //Add slide from right animation
            storyboard.AddSlideFromLeft(seconds, width == 0 ? frameworkElement.ActualWidth : width, keepMargin: keepMargin);

            //Add fade in animation
            storyboard.AddFadeIn(seconds);

            //Begin the storyboard animation on the specific page we pass in
            storyboard.Begin(frameworkElement);

            //Make element visible only if we are animating

            frameworkElement.Visibility = Visibility.Visible;

            //Await for the animation to finish right on time
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element in from bottom, plus the fade in effect
        /// </summary>
        /// <param name="frameworkElement">The element to animate</param>
        /// <param name="seconds">The time it will take to complete the animation</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="height">The animation height to animate to. If not specified the elements width is used.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromBottomAsync(this FrameworkElement frameworkElement, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            //Create the storyboard
            var storyboard = new Storyboard();

            //Add slide from bottom animation
            storyboard.AddSlideFromBottom(seconds, height == 0 ? frameworkElement.ActualHeight : height, keepMargin: keepMargin);

            //Add fade in animation
            storyboard.AddFadeIn(seconds);

            //Start the animation
            storyboard.Begin(frameworkElement);

            //Make element visible only if we are animating

            frameworkElement.Visibility = Visibility.Visible;

            //Await for the animation to finish on the right time
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region SlideAndFadeOut

        /// <summary>
        /// Slides an element out to the left, plus the fade out effect
        /// </summary>
        /// <param name="frameworkElement">The element to animate</param>
        /// <param name="seconds">The time it will take to complete the animation</param>
        /// <param name="width">The animation width to animate to. If not specified the elements width is used.</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement frameworkElement, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //Create the storyboard
            var storyboard = new Storyboard();

            //Add slide out to left animation
            storyboard.AddSlideToLeft(seconds, width == 0 ? frameworkElement.ActualWidth : width, keepMargin: keepMargin);

            //Add fade out animation
            storyboard.AddFadeOut(seconds);

            //Start the animation
            storyboard.Begin(frameworkElement);

            //Make element visible only if we are animating            
            frameworkElement.Visibility = Visibility.Visible;

            //Await for the animation to finish right on time
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the right, plus the fade out effect
        /// </summary>
        /// <param name="frameworkElement">The element to animate</param>
        /// <param name="seconds">The time it will take to complete the animation</param>
        /// <param name="width">The animation width to animate to. If not specified the elements width is used.</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement frameworkElement, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            //Create the storyboard
            var storyboard = new Storyboard();

            //Add slide out to left animation
            storyboard.AddSlideToRight(seconds, width == 0 ? frameworkElement.ActualWidth : width, keepMargin: keepMargin);

            //Add fade out animation
            storyboard.AddFadeOut(seconds);

            //Start the animation
            storyboard.Begin(frameworkElement);

            //Make element visible only if we are animating
            if (seconds == 0)
                frameworkElement.Visibility = Visibility.Visible;

            //Await for the animation to finish right on time
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to bottom, plus the fade out effect
        /// </summary>
        /// <param name="frameworkElement">The element to animate</param>
        /// <param name="seconds">The time it will take to complete the animation</param>
        /// <param name="height">The animation height to animate to. If not specified the elements width is used.</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToBottomAsync(this FrameworkElement frameworkElement, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            //Create storyboard
            var storyboard = new Storyboard();

            //Add slide out to bottom animation
            storyboard.AddSlideToBottom(seconds, height == 0 ? frameworkElement.ActualHeight : height, keepMargin: keepMargin);

            //Add fade out animation
            storyboard.AddFadeOut(seconds);

            //Begin storyboard animation
            storyboard.Begin(frameworkElement);

            //Make element visible only if we are animating            
            //frameworkElement.Visibility = Visibility.Visible;

            //Await for the animation to finish right on time
            await Task.Delay((int)(seconds * 1000));

            //Make element hidden
            frameworkElement.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Slide In / Out

        /// <summary>
        /// Slides an element in
        /// </summary>
        /// <param name="frameworkElement">The element to animate</param>
        /// <param name="direction">The direction of the slide</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>       
        /// <param name="size">The animation width/height to animate to. If not specified the elements size is used</param>
        /// <param name="firstLoad">Indicates if this is the first load</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInAsync(this FrameworkElement frameworkElement, AnimationSlideInDirection direction, bool firstLoad, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            // Create the storyboard
            var storyboard = new Storyboard();

            // Slide in the correct direction
            switch (direction)
            {
                // Add slide from left animation
                case AnimationSlideInDirection.Left:
                    storyboard.AddSlideFromLeft(seconds, size == 0 ? frameworkElement.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide from right animation
                case AnimationSlideInDirection.Right:
                    storyboard.AddSlideFromRight(seconds, size == 0 ? frameworkElement.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide from top animation
                case AnimationSlideInDirection.Top:
                    storyboard.AddSlideFromTop(seconds, size == 0 ? frameworkElement.ActualHeight : size, keepMargin: keepMargin);
                    break;
                // Add slide from bottom animation
                case AnimationSlideInDirection.Bottom:
                    storyboard.AddSlideFromBottom(seconds, size == 0 ? frameworkElement.ActualHeight : size, keepMargin: keepMargin);
                    break;
            }
            // Add fade in animation
            storyboard.AddFadeIn(seconds);

            // Start animating
            storyboard.Begin(frameworkElement);

            // Make page visible only if we are animating or its the first load
            if (seconds != 0 || firstLoad)
                frameworkElement.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>        
        /// Slides an element out
        /// </summary>
        /// <param name="frameworkElement">The element to animate</param>
        /// <param name="direction">The direction of the slide (this is for the reverse slide out action, so Left would slide out to left)</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>        
        /// <param name="size">The animation width/height to animate to. If not specified the elements size is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutAsync(this FrameworkElement frameworkElement, AnimationSlideInDirection direction, float seconds = 0.3f, bool keepMargin = true, int size = 0)
        {
            // Create the storyboard
            var storyboard = new Storyboard();

            // Slide in the correct direction
            switch (direction)
            {
                // Add slide to left animation
                case AnimationSlideInDirection.Left:
                    storyboard.AddSlideToLeft(seconds, size == 0 ? frameworkElement.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide to right animation
                case AnimationSlideInDirection.Right:
                    storyboard.AddSlideToRight(seconds, size == 0 ? frameworkElement.ActualWidth : size, keepMargin: keepMargin);
                    break;
                // Add slide to top animation
                case AnimationSlideInDirection.Top:
                    storyboard.AddSlideToTop(seconds, size == 0 ? frameworkElement.ActualHeight : size, keepMargin: keepMargin);
                    break;
                // Add slide to bottom animation
                case AnimationSlideInDirection.Bottom:
                    storyboard.AddSlideToBottom(seconds, size == 0 ? frameworkElement.ActualHeight : size, keepMargin: keepMargin);
                    break;
            }

            // Add fade in animation
            storyboard.AddFadeOut(seconds);

            // Start animating
            storyboard.Begin(frameworkElement);

            // Make page visible only if we are animating
            if (seconds != 0)
                frameworkElement.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));

            // Make element invisible
            frameworkElement.Visibility = Visibility.Hidden;
        }

        #endregion

        #region FadeIn

        /// <summary>
        /// Fades in an element
        /// </summary>
        /// <param name="frameworkElement">The element to animate</param>
        /// <param name="seconds">The time it takes to animate the element</param>
        /// <param name="firstLoad">Indicates if this is the first load</param>
        /// <returns></returns>
        public static async Task FadeInAsync(this FrameworkElement frameworkElement, bool firstLoad, float seconds = 0.3f)
        {
            //Create storyboard
            var storyboard = new Storyboard();

            //Add fade in animation
            storyboard.AddFadeIn(seconds);

            //Begin animation
            storyboard.Begin(frameworkElement);

            // Make page visible only if we are animating or its the first load
            if (seconds != 0 || firstLoad)
                frameworkElement.Visibility = Visibility.Visible;

            //Wait for the animation to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region FadeOut

        /// <summary>
        /// Fades out an element
        /// </summary>
        /// <param name="frameworkElement">The element to animate</param>
        /// <param name="seconds">The time it takes to animate the element</param>
        /// <param name="firstLoad">Indicates if this is the first load</param>
        /// <returns></returns>
        public static async Task FadeOutAsync(this FrameworkElement frameworkElement, float seconds = 0.3f)
        {
            //Create a storyboard
            var storyboard = new Storyboard();

            //Add fade out animation
            storyboard.AddFadeOut(seconds);

            //Begin the animation
            storyboard.Begin(frameworkElement);

            /// Make page visible only if we are animating or its the first load
            if (seconds != 0)
                frameworkElement.Visibility = Visibility.Visible;

            //Wait for the animation to finish
            await Task.Delay((int)(seconds * 1000));

            // Fully hide our element
            frameworkElement.Visibility = Visibility.Collapsed;
        }

        #endregion
    }


    ///Quick Note!!!!
    ///In our slide animations we keep track of the window Width since our margin will always be relative to that
    ///In the case of expandind or shrinking the window the animation might seem off if the window's actual coordonates are't counted for
}
