using Fasetto.Word.Core;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// Handles reading/writting and querying the file sistem
    ///</sumary>
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Writes the text to the specified file path
        /// </summary>
        /// <param name="text"> The text we want to write to the file</param>
        /// <param name="path"> The path to the file </param>
        /// <param name="append"> A flag indicating if we want to write at the end of the file, otherwise we overwrite any existing file</param>
        /// <returns></returns>
        public async Task WriteTextToFileAsync(string text, string path, bool append = false)
        {
            //TODO: add exception cathing

            //Normalize Path
            path = NormalizePath(path);

            //Rezolve to absolute path
            path = ResolvePath(path);

            //Lock the task
            await AsyncAwaiter.AwaitAsync(nameof(FileManager) + path, async () => 
            {                
                // Run the synchronous file access as a new task
                await IoC.Task.Run(() =>
                {
                    // Write the log message to file
                    using (var fileStream = (TextWriter)new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
                    {
                        fileStream.Write(text);                        
                    }
                });
            });
        }

        /// <summary>
        /// Normalizes a path based on the current operating system
        /// </summary>
        /// <param name="path"> The path to normalize </param>
        /// <returns></returns>
        public string NormalizePath(string path)
        {
            // If we are on windows...
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Replace any forward slashes with back slashes
                return path?.Replace("/", "\\").Trim();
            }
            // If we are on linux or mac...
            else
            {
                // Replace any back slashes with forward slashes
                return path?.Replace("\\", "/").Trim();
            }
        }

        /// <summary>
        /// Resolves any relative elements of the path to absolute
        /// </summary>
        /// <param name="path"> The path to resolve </param>
        /// <returns></returns>
        public string ResolvePath(string path)
        {
            // Resolve path
            return Path.GetFullPath(path);
        }
    }
}
