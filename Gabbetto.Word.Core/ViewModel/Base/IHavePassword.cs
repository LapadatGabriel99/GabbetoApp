using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// An interface for a class that can provide a password
    /// </summary>
    public interface IHavePassword
    {
        /// <summary>
        /// The secure password
        /// </summary>
         SecureString SecurePassword { get; }
    }
}
