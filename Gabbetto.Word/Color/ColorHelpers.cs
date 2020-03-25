using System;
using System.Globalization;
using System.Windows.Media;

namespace Fasseto.Word
{
    ///<sumary>
    /// A helper class for <see cref="System.Windows.Media.Color"/>
    ///</sumary>
    public static class ColorHelpers
    {
        private static readonly string _defaultStringRGB = "FFFFFF";

        /// <summary>
        /// Converts a RGB string to a <see cref="Color"/>
        /// </summary>
        /// <param name="colorCode">the string to convert</param>
        /// <returns></returns>
        public static Color FromStringRGBToColor(this string colorCode)
        {
            colorCode = colorCode.TrimStart('#');

            colorCode = colorCode.ToUpper();

            Color color = new Color();

            if (colorCode.Length == 6)
            {
                color = Color.FromRgb(
                                (byte)int.Parse(colorCode.Substring(0, 2), NumberStyles.HexNumber),
                                (byte)int.Parse(colorCode.Substring(2, 2), NumberStyles.HexNumber),
                                (byte)int.Parse(colorCode.Substring(4, 2), NumberStyles.HexNumber));
            }
            else
            {
                color = Color.FromRgb(
                                (byte)int.Parse(_defaultStringRGB.Substring(0, 2), NumberStyles.HexNumber),
                                (byte)int.Parse(_defaultStringRGB.Substring(2, 2), NumberStyles.HexNumber),
                                (byte)int.Parse(_defaultStringRGB.Substring(4, 2), NumberStyles.HexNumber));
            }

            return color;
        }

        /// <summary>
        /// Converts a ARGB string to a <see cref="Color"/>
        /// </summary>
        /// <param name="colorCode">the string to convert</param>
        /// <param name="a">the A value from RGB</param>
        /// <returns></returns>
        public static Color FromStringARGBToColor(this string colorCode, string a = "FF")
        {
            colorCode.TrimStart('#');

            colorCode.ToUpper();

            Color color = new Color();

            if (colorCode.Length == 8)
            {
                a = a.ToUpper();

                color = Color.FromArgb(
                                (byte)int.Parse(a.Substring(0, 2), NumberStyles.HexNumber),
                                (byte)int.Parse(colorCode.Substring(0, 2), NumberStyles.HexNumber),
                                (byte)int.Parse(colorCode.Substring(2, 2), NumberStyles.HexNumber),
                                (byte)int.Parse(colorCode.Substring(4, 2), NumberStyles.HexNumber));
            }
            else
            {
                color = Color.FromArgb(
                                (byte)int.Parse(a.Substring(0, 2), NumberStyles.HexNumber),
                                (byte)int.Parse(_defaultStringRGB.Substring(0, 2), NumberStyles.HexNumber),
                                (byte)int.Parse(_defaultStringRGB.Substring(2, 2), NumberStyles.HexNumber),
                                (byte)int.Parse(_defaultStringRGB.Substring(4, 2), NumberStyles.HexNumber));
            }

            return color;
        }
    }
}
