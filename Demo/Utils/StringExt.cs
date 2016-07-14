using System.Text.RegularExpressions;

namespace Demo.Utils
{
    public static class StringExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="noHTML">remove HTML tag</param>
        /// <param name="suffix">default ""</param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength, bool noHTML = false, string suffix = "")
        {
            // Todo: 英文避免斷到單字

            if (string.IsNullOrEmpty(value)) return value;
            if (noHTML) value = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();

            //return (value.Length <= maxLength || value.IndexOf(" ", maxLength) == -1) ? value : value.Substring(0, value.IndexOf(" ", maxLength)) + suffix;
            return (value.Length <= maxLength ? value : value.Substring(0, maxLength)) + suffix;
        }
    }
}