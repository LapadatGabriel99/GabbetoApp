using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word
{
    /// <summary>
    /// Styles of page animation for appearing/dissapearing
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// No animation
        /// </summary>
        None = 0,

        /// <summary>
        /// The page slides in and fades in from the right
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        /// The page slides out and fades to the left
        /// </summary>
        SlideAndFadeOutToLeft = 2
    }
}
