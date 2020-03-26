using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Converts a <see cref="IconType"/> to a font awesome string
    /// </summary>
    public static class IconTypeExtensions
    {
        /// <summary>
        /// Converts a <see cref="IconType"/> to a font awesome string
        /// </summary>
        /// <param name="type">the type to convert</param>
        /// <returns></returns>
        public static string ToFontAweseome(this IconType type)
        {
            //Return a font awesome string based on the icon type
            switch (type)
            {                
                case IconType.Picture:
                    return "\uf1c5";

                case IconType.File:
                    return "\uf0f6";

                default:
                    return null;
            }
        }
    }
}
