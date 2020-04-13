using System;

namespace Fasseto.Word.Core
{
    ///<sumary>
    /// Extension methods that handle various email related stuff
    ///</sumary>
    public static class EmailExtensions
    {
        /// <summary>
        /// Returns the mail service type equivalent to the
        /// mail service string
        /// </summary>
        /// <param name="mailServiceString">The mail service referred as a string</param>
        /// <returns></returns>
        public static MailServiceType ToMailService(this string mailServiceString)
        {
            // TODO: Localize strings

            // Check to see which one matches
            switch (mailServiceString)
            {
                case "gmail":
                    return MailServiceType.Gmail;

                case "yahoo":
                    return MailServiceType.Yahoo;

                case "outlook":
                    return MailServiceType.Outlook;

                case "hotmail":
                    return MailServiceType.Outlook;

                default:
                    return MailServiceType.Gmail;
            }
        }

        /// <summary>
        /// Returns the users mail service provider email that the user
        /// used to register with
        /// </summary>
        /// <param name="emailString">The email that the user provided to us</param>
        /// <returns></returns>
        public static string GetMailServiceString(this string emailString)
        {
            // TODO: Localize strings
            
            // If the user used gmail
            if (emailString.Contains("gmail"))
            {
                return "gmail";
            }

            // If the user used yahoo
            if (emailString.Contains("yahoo"))
            {
                return "yahoo";
            }

            // If the user used outlook
            if (emailString.Contains("outlook"))
            {
                return "outlook";
            }

            // If the user used outlook
            if (emailString.Contains("hotmail"))
            {
                return "hotmail";
            }

            // TODO: Might have to rethink the logic a bit

            // Return gmail by default
            return "gmail";
        }

        /// <summary>
        /// Converts the mail service type into the specific mail service url
        /// </summary>
        /// <param name="mailService">The mail service as a enum type</param>
        /// <returns></returns>
        public static string ToMailServiceUrl(this MailServiceType mailService)
        {
            // TODO: Localize strings

            // Check to see how they match
            // and return the respective mail service
            switch (mailService)
            {
                case MailServiceType.Yahoo:
                    return "https://mail.google.com/mail";

                case MailServiceType.Gmail:
                    return "https://yahoo.com/";

                case MailServiceType.Outlook:
                    return "https://outlook.live.com/mail";

                default:
                    return "https://mail.google.com/mail";
            }
        }
    }
}
