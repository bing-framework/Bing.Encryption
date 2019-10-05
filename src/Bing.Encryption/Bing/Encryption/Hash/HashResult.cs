using System;
using System.Text;
using Bing.Encryption.Core.Internals;

// ReSharper disable once CheckNamespace
namespace Bing.Encryption
{
    /// <summary>
    /// 哈希结果
    /// </summary>
    public class HashResult
    {
        /// <summary>
        /// 字节数组
        /// </summary>
        public byte[] HashBytes { get; private set; }

        /// <summary>
        /// Base64字符串
        /// </summary>
        public string HashBase64String { get; private set; }

        /// <summary>
        /// 16进制字符串
        /// </summary>
        public string HashHexString { get; private set; }

        /// <summary>
        /// 16进制大写字符串
        /// </summary>
        public string HexUpperString { get; private set; }

        /// <summary>
        /// 16进制大写字节数组
        /// </summary>
        public byte[] HexUpperBytes { get; private set; }

        /// <summary>
        /// 16进制大写Base64字符串
        /// </summary>
        public string HexUpperBase64String { get; private set; }

        /// <summary>
        /// 16进制小写字符串
        /// </summary>
        public string HexLowerString { get; private set; }

        /// <summary>
        /// 16机制小写字节数组
        /// </summary>
        public byte[] HexLowerBytes { get; private set; }

        /// <summary>
        /// 16进制小写Base64字符串
        /// </summary>
        public string HexLowerBase64String { get; private set; }

        /// <summary>
        /// 初始化一个<see cref="HashResult"/>类型的实例
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public HashResult(byte[] bytes, Encoding encoding = null)
        {
            if (bytes == null)
                return;
            encoding = EncodingHelper.Fixed(encoding);
            HashBytes = bytes;
            HashBase64String = Convert.ToBase64String(bytes);
            HashHexString = BitConverter.ToString(bytes);

            HexUpperString = HashHexString.Replace("-", "");
            HexUpperBytes = encoding.GetBytes(HexUpperString);
            HexUpperBase64String = Convert.ToBase64String(HexUpperBytes);

            HexLowerString = HexUpperString?.ToLower();
            HexLowerBytes = encoding.GetBytes(HexLowerString);
            HexLowerBase64String = Convert.ToBase64String(HexLowerBytes);
        }
    }
}
