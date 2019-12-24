using System;
using System.Security.Cryptography;
using System.Text;
using Bing.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Bing.Encryption
{
    /// <summary>
    /// SHA256 哈希加密提供程序
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class SHA256HashingProvider : SHAHashingBase
    {
        /// <summary>
        /// 初始化一个<see cref="SHA256HashingProvider"/>类型的实例
        /// </summary>
        private SHA256HashingProvider() { }

        /// <summary>
        /// 获取字符串的 SHA256 哈希值，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="data">待加密的数据</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static HashResult Signature(string data, Encoding encoding = null) =>
            Encrypt<SHA256CryptoServiceProvider>(data, encoding);

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="comparison">对比的值</param>
        /// <param name="data">待加密的值</param>
        /// <param name="func">比较函数</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        public static bool Verify(string comparison, string data, Func<HashResult, string> func,
            Encoding encoding = null) => comparison == func(Signature(data, encoding));
    }
}
