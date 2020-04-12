using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// A response to a SendGrid SendMessage call
    /// </summary>
    public class SendGridResponse
    {
        /// <summary>
        /// The list of possible errors when sending an email
        /// </summary>
        public List<SendGridResponseError> Errors { get; set; }
    }
}
