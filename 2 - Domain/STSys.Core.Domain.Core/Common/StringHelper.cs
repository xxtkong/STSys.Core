using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace STSys.Core.Domain.Core.Common
{
    public static class StringHelper
    {
        public static string SubStr(string contents, int length, bool append = false)
        {
            if (length < 1) return string.Empty;
            if (string.IsNullOrEmpty(contents)) return contents;
            int totalCount = System.Text.Encoding.Default.GetByteCount(contents);
            if (totalCount <= length) return contents;

            int x = 0;
            int index = 0;
            char[] chars = contents.ToCharArray();
            foreach (var item in chars)
            {
                int count = System.Text.Encoding.Default.GetByteCount(chars, index, 1);
                int tmp = x + count;
                if (tmp > length)
                {
                    string contact = contents.Substring(0, index);
                    return append ? contact + "..." : contact;
                }
                else
                {
                    x = tmp;
                }
                index++;
            }
            return contents;
        }

        /// <summary>
        /// 截取字符串(length为0时返回全部数据源)
        /// </summary>
        /// <param name="content">数据源</param>
        /// <param name="length">长度</param>
        /// <param name="fix">后缀</param>
        /// <returns></returns>
        public static string GetSubString(this string content, int length, string fix = "...")
        {
            if (string.IsNullOrEmpty(content)) return string.Empty;
            content = NoHTML(content);
            if (length == 0) return content;
            int cl = content.Length;//传入的字符串长度
            if (cl > length)
                return (content.Substring(0, length) + fix);
            else
                return content;
        }
        /// <summary>
        /// 截取字符串(length为0时返回全部数据源)
        /// </summary>
        /// <param name="content"></param>
        /// <param name="length"></param>
        /// <param name="paddingChar">左填充字符</param>
        /// <param name="fix"></param>
        /// <returns></returns>
        public static string GetSubString(this string content, int length, char paddingChar, string fix = "...")
        {
            if (string.IsNullOrEmpty(content)) return string.Empty;
            content = NoHTML(content);
            if (length == 0) return content;
            int cl = content.Length;//传入的字符串长度
            if (cl > length)
                return (content.Substring(0, length) + fix);
            else
                return content.PadLeft(length, paddingChar);
        }
        public static string GetSubString(this string content, int startindex, int length, string fix = "...")
        {
            if (string.IsNullOrEmpty(content)) return string.Empty;
            content = NoHTML(content);
            if (startindex == 0) return content;
            if (length <= 0)
                return content;
            int cl = content.Length;//传入的字符串长度
            if (cl > startindex + length)
                return (content.Substring(startindex, length) + fix);
            else
                return content.Substring(startindex) + fix;
        }
        public static string NoHTML(this string Htmlstring)
        {
            Htmlstring.Replace(" ", "");
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = Htmlstring.Trim();
            return Htmlstring;
        }
    }
}
