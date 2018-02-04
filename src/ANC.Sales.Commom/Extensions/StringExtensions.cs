using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static ANC.Sales.Commom.Constants;

namespace ANC.Sales.Commom.Extensions
{
    public static class StringExtensions
    {
        #region Emails

        /// <summary>
        /// Indicates whether a string is a valid email.
        /// </summary>
        /// <param name="text">The email string that must be validated.</param>
        /// <returns>Returns true if the given string is an email, else false.</returns>
        public static bool IsValidEmail(this string text)
        {
            if (String.IsNullOrEmpty(text))
                return false;

            text = text.Trim();

            try
            {
                return Regex.IsMatch(text, @"\A" + EMAIL_PATTERN + @"\Z", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Extracts all email from a given string.
        /// </summary>
        /// <param name="text">The given string.</param>
        /// <returns>A collection of all email found in the given string.</returns>
        public static IEnumerable<String> ExtractEmails(this string text)
        {
            Regex rx = new Regex(EMAIL_PATTERN, RegexOptions.IgnoreCase);
            return rx.Matches(text).Cast<Match>().Select((m) => m.Value.ToString());
        }

        #endregion


        #region Mimes types

        /// <summary>
        /// Default MIME type for a resource.
        /// </summary>
        private const string DefaultMimeType = "application/octet-stream";

        /// <summary>
        /// Mapping from file extensions to corresponding MIME types.
        /// </summary>
        private static readonly Dictionary<string, string> FileExtensionsMimes = new Dictionary<string, string>()
        {
            // Text
            { "css", "text/css"},
            { "csv", "text/csv"},
            { "html", "text/html"},
            { "htm", "text/html"},
            { "txt", "text/plain"},

            // Image

            { "jpg", "image/jpeg"},
            { "jpeg", "image/jpeg"},
            { "bmp", "image/bmp"},
            { "png", "image/png"},
            { "gif", "image/gif"},
            { "tiff", "image/tiff"},
            { "tif", "image/tiff"},

            // Audio
            
            { "mp3", "audio/mpeg"},
            { "wav", "audio/x-wav"},
            { "wma", "audio/x-ms-wma"},

            // Video
            
            { "mp4", "video/mp4" },
            { "wmv", "video/x-ms-wmv"},

            // Application
            
            { "pdf", "application/pdf"},
            { "json", "application/json"},
            { "xml", "application/xml"},
            { "zip", "application/zip"},
            { "ogg", "application/ogg"},
            { "js", "application/javascript"},

            // Office
            
            { "xls", "application/vnd.ms-excel"},
            { "ppt", "application/vnd.ms-powerpoint"},
            { "doc", "application/msword"},
            { "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
            { "pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
        };

        /// <summary>
        /// Returns the MIME type associated to a file path (based on its extension).
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <returns>The MIME type if found, else a default one.</returns>
        public static string GetMimeType(this string path)
        {
            var ext = Path.GetExtension(path);

            if (!String.IsNullOrEmpty(ext))
            {
                ext = ext.TrimStart('.');

                if (FileExtensionsMimes.ContainsKey(ext))
                {
                    return FileExtensionsMimes[ext];
                }
            }

            return DefaultMimeType;
        }

        #endregion
    }
}
