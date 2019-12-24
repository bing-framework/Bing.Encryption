using System.Security.Cryptography;
using System.Text;
using Bing.Encryption.Core.Internals.Extensions;

// ReSharper disable once CheckNamespace
namespace Bing.Encryption
{
    /// <summary>
    /// MD4 哈希加密提供程序
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class MD4HashingProvider
    {
        /// <summary>
        /// 获取字符串的 MD4 哈希值，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static string Signature(string value, Encoding encoding = null) => SignatureHash(value, encoding).ToHexString();

        /// <summary>
        /// 获取字符串的 MD4 哈希值
        /// </summary>
        /// <param name="value">待加密的字节数组</param>
        public static string Signature(byte[] value) => Core(value).ToHexString();

        /// <summary>
        /// 获取字节数组的 MD4 哈希值，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static byte[] SignatureHash(string value, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            return Core(encoding.GetBytes(value));
        }

        /// <summary>
        /// 获取字节数组的 MD4 哈希值
        /// </summary>
        /// <param name="value">待加密的字节数组</param>
        public static byte[] SignatureHash(byte[] value) => Core(value);

        /// <summary>
        /// 核心加密算法
        /// </summary>
        /// <param name="value">待加密的值</param>
        private static byte[] Core(byte[] value)
        {
            using (var md4 = new MD4CryptoServiceProvider())
                return md4.ComputeHash(value);
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="comparison">对比的值</param>
        /// <param name="value">待加密的值</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static bool Verify(string comparison, string value, Encoding encoding = null) =>
            comparison == Signature(value, encoding);
    }
}
