using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// A helper class for <see cref="ColorType"/>
    ///</sumary>
    public static class ColorTypeExtensions
    {
        /// <summary>
        /// Converts a <see cref="ColorType"/> to a RGB string
        /// </summary>
        /// <param name="type">the type to convert</param>
        /// <returns></returns>
        public static string ToStringRGB(this ColorType type)
        {
            switch (type)
            {
                case ColorType.ForegroundLight:
                    return "#ffffff";

                case ColorType.WordRed:
                    return "#ff4747";

                case ColorType.WordGreen:
                    return "#00c541";

                case ColorType.WordOrange:
                    return "#ffa800";

                case ColorType.WordBlue:
                    return "#3099c5";

                case ColorType.WordDarkBlue:
                    return "#0c6991";

                default:
                    return null;
            }
        }
    }
}
