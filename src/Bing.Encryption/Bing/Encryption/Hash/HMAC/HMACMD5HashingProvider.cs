using System;
using System.Text;
using Bing.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Bing.Encryption
{
    /// <summary>
    /// HMAC_MD5 哈希加密提供程序
    /// </summary>
    public sealed class HMACMD5HashingProvider : HMACHashingBase
    {
        /// <summary>
        /// 初始化一个<see cref="HMACMD5HashingProvider"/>类型的实例
        /// </summary>
        private HMACMD5HashingProvider() { }

        /// <summary>
        /// 获取字符串的 HMAC_MD5 哈希值，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="data">待加密的数据</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static HashResult Signature(string data, string key, Encoding encoding = null) =>
            Encrypt<System.Security.Cryptography.HMACMD5>(data, key, encoding);

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="comparison">对比的值</param>
        /// <param name="data">待加密的数据</param>
        /// <param name="key">密钥</param>
        /// <param name="func">比较函数</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static bool Verify(string comparison, string data, string key, Func<HashResult, string> func,
            Encoding encoding = null) => comparison == func(Signature(data, key, encoding));
    }
}
