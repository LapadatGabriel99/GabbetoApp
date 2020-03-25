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
    /// Page animation helpers in specific ways
    /// </summary>
    public static class PageAnimationHelpers
    {
        /// <summary>
        /// Slides a page in from the right, plus the fade in effect
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">The time it will take to complete the animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this Page page, float seconds)
        {
            //Create the storyboard
            var storyboard = new Storyboard();

            //Add slide from right animation
            storyboard.AddSlideFromRight(seconds, page.WindowWidth);

            //Add fade in animation
            storyboard.AddFadeIn(seconds);

            //Begin the storyboard animation on the specific page we pass in
            storyboard.Begin(page);

            //Make that page visible
            page.Visibility = Visibility.Visible;

            //Await for the animation to finish right on time
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a page out to the left, plus the fade out effect
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">The time it will take to complete the animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this Page page, float seconds)
        {
            //Create the storyboard
            var storyboard = new Storyboard();

            //Add slide out to left animation
            storyboard.AddSlideToLeft(seconds, page.WindowWidth);

            //Add fade out animation
            storyboard.AddFadeOut(seconds);

            //Start the animation
            storyboard.Begin(page);

            //Make page visible
            page.Visibility = Visibility.Visible;

            //Await for the animation to finish right on time
            await Task.Delay((int)(seconds * 1000));
        }
    }

    ///Quick Note!!!!
    ///In our slide animations we keep track of the window Width since our margin will always be relative to that
    ///In the case of expandind or shrinking the window the animation might seem off if the window's actual coordonates are't counted for
}
