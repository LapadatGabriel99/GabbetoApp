using System;
using System.Linq;

namespace Fasseto.Word.Core
{
    // TODO: Try adding this logic in the ProjectUniversal framework

    ///<sumary>
    /// Extension methods that handle name restrictions
    ///</sumary>
    public static class NameExtensions
    {
        /// <summary>
        /// Determines if the specified string contains any digits or special characters
        /// </summary>
        /// <param name="content">The content string</param>
        /// <returns></returns>
        public static bool HasDigitOrSpecialCharacter(this string content)
        {

            // Here are a series of checks that are made with the purpose trying to validate
            // the name as better as possible

            if(content.Where(c => char.IsDigit(c)).ToList().Count != 0)
            {
                return true;
            }

            if(content.Where(c => char.IsPunctuation(c) || 
                                  char.IsNumber(c) || 
                                  char.IsSymbol(c) || 
                                  char.IsControl(c) || 
                                  char.IsSurrogate(c) || 
                                  char.IsHighSurrogate(c) || 
                                  char.IsSeparator(c)).ToList().Count != 0)
            {
                return true;
            }

            return false;
        }
    }
}
