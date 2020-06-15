using System;
using System.Drawing;

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

                case ColorType.WordDarkGreen:
                    return "#009631";

                case ColorType.WordDarkRed:
                    return "#ec0000";

                case ColorType.WordTransparentBlue:
                    return "#003099c5";

                case ColorType.WordLightBlue:
                    return "#45b6e5";

                case ColorType.WordAlmostVeryLightBlue:
                    return "#c3e5f3";

                case ColorType.WordVeryLightBlue:
                    return "#ecf6fb";

                case ColorType.BackgroundLight:
                    return "#efefef";

                case ColorType.BackgroundVeryLight:
                    return "#fafafa";

                case ColorType.ForegroundMain:
                    return "#686868";

                case ColorType.ForegroundVeryDark:
                    return "#000000";

                case ColorType.ForegroundDark:
                    return "#bdbdbd";

                case ColorType.ForegroundLightDark:
                    return "#F2F3F5";

                default:
                    return null;
            }
        }
    }
}
