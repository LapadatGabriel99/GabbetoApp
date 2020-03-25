using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    public interface IFileManager
    {
        /// <summary>
        /// Writes the text to the specified file path
        /// </summary>
        /// <param name="text"> The text we want to write to the file</param>
        /// <param name="path"> The path to the file </param>
        /// <param name="append"> A flag indicating if we want to write at the end of the file, otherwise we overwrite any existing file</param>
        /// <returns></returns>
        Task WriteTextToFileAsync(string text, string path, bool append = false);

        /// <summary>
        /// Normalizes a path based on the current operating system
        /// </summary>
        /// <param name="path"> The path to normalize </param>
        /// <returns></returns>
        string NormalizePath(string path);

        /// <summary>
        /// Resolves any relative elements of the path to absolute
        /// </summary>
        /// <param name="path"> The path to resolve </param>
        /// <returns></returns>
        string ResolvePath(string path);
    }
}
