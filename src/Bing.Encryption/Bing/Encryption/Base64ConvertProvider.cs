using System;
using System.Text;
using Bing.Encryption.Core.Internals;

namespace Bing.Encryption
{
    /// <summary>
    /// Base64 转换提供程序
    /// </summary>
    public static class Base64ConvertProvider
    {
        /// <summary>
        /// Base64
        /// </summary>
        private const string BASE64 = "===========================================+=+=/0123456789=======ABCDEFGHIJKLMNOPQRSTUVWXYZ====/=abcdefghijklmnopqrstuvwxyz=====";

        /// <summary>
        /// 加密，返回Base64字符串
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static string Encode(string value, Encoding encoding = null)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (encoding == null)
                encoding=Encoding.UTF8;
            return Convert.ToBase64String(encoding.GetBytes(value));
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="value">待解密的值</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static string Decode(string value, Encoding encoding = null)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (encoding == null)
                encoding = Encoding.UTF8;
            return encoding.GetString(Convert.FromBase64String(value));
        }

        /// <summary>
        /// 转换为Base64字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        public static string ToBase64String(byte[] bytes) => Convert.ToBase64String(bytes);

        /// <summary>
        /// 转换为Base64字符串
        /// </summary>
        /// <param name="data">待加密的数据</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static string ToBase64String(string data, Encoding encoding = null)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            encoding = EncodingHelper.Fixed(encoding);
            return ToBase64String(encoding.GetBytes(data));
        }

        /// <summary>
        /// 将Base64字符串转换为普通字符串
        /// </summary>
        /// <param name="data">待解密的数据</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static string FromBase64String(string data, Encoding encoding = null)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            encoding = EncodingHelper.Fixed(encoding);
            return encoding.GetString(Convert.FromBase64String(data));
        }

        /// <summary>
        /// 转换为Base64Url字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        public static string ToBase64UrlString(byte[] bytes)
        {
            var result = new StringBuilder(Convert.ToBase64String(bytes).TrimEnd('='));
            result.Replace('+', '-');
            result.Replace('/', '_');
            return result.ToString();
        }

        /// <summary>
        /// 转换为Base64Url字符串
        /// </summary>
        /// <param name="data">待加密的数据</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static string ToBase64UrlString(string data, Encoding encoding = null)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            encoding = EncodingHelper.Fixed(encoding);
            return ToBase64UrlString(encoding.GetBytes(data));
        }

        /// <summary>
        /// 将Base64Url字符串转换为字节数组
        /// </summary>
        /// <param name="base64UrlString">Base64Url字符串</param>
        public static byte[] FromBase64UrlString(string base64UrlString)
        {
            var sb = new StringBuilder();
            foreach (var c in base64UrlString)
            {
                if(c>=128)
                    continue;
                var k = BASE64[c];
                if(k=='=')
                    continue;
                sb.Append(k);
            }

            var len = sb.Length;
            var padChars= (len % 4) == 0 ? 0 : (4 - (len % 4));
            if (padChars > 0)
                sb.Append(string.Empty.PadRight(padChars, '='));
            return Convert.FromBase64String(sb.ToString());
        }

        /// <summary>
        /// 将Base64Url字符串转换为普通字符串
        /// </summary>
        /// <param name="base64UrlString"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromBase64UrlString(string base64UrlString, Encoding encoding) =>
            encoding.GetString(FromBase64UrlString(base64UrlString));
    }
}
