﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A page of the application
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// The initial login page
        /// </summary>
        Login = 0,

        /// <summary>
        /// Main chat page
        /// </summary>
        Chat = 1,

        /// <summary>
        /// The register page
        /// </summary>
        Register = 2,

        /// <summary>
        /// The post register page
        /// </summary>
        PostRegister = 3,

        /// <summary>
        /// The optional credentials page
        /// </summary>
        OptionalCredentials = 4
    }
}
