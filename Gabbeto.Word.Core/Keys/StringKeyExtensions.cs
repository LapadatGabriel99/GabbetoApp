using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// Extension methods for a <see cref="string"/>
    ///</sumary>
    public static class StringKeyExtensions
    {
        public static string GetUniqueKey(this string content, string className = "", string functionName = "")
        {
            return content +  className + functionName;
        }
    }
}
