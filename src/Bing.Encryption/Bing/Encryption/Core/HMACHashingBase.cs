using System.Security.Cryptography;
using System.Text;
using Bing.Encryption.Core.Internals;

namespace Bing.Encryption.Core
{
    /// <summary>
    /// HMAC哈希加密基类
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public abstract class HMACHashingBase
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <typeparam name="TKeyedHashAlgorithm">密钥哈希算法类型</typeparam>
        /// <param name="data">待加密的数据</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码类型。默认为<see cref="Encoding.UTF8"/></param>
        protected static HashResult Encrypt<TKeyedHashAlgorithm>(string data, string key, Encoding encoding = null)
            where TKeyedHashAlgorithm : KeyedHashAlgorithm, new() =>
            new HashResult(EncryptBytes<TKeyedHashAlgorithm>(data, key, encoding), encoding);

        /// <summary>
        /// 加密
        /// </summary>
        /// <typeparam name="TKeyedHashAlgorithm">密钥哈希算法类型</typeparam>
        /// <param name="data">待加密的数据</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码类型。默认为<see cref="Encoding.UTF8"/></param>
        protected static byte[] EncryptBytes<TKeyedHashAlgorithm>(string data, string key, Encoding encoding = null)
            where TKeyedHashAlgorithm : KeyedHashAlgorithm, new()
        {
            Checker.Data(data);
            Checker.Key(key);
            encoding = EncodingHelper.Fixed(encoding);
            using (KeyedHashAlgorithm hash = new TKeyedHashAlgorithm())
            {
                hash.Key = encoding.GetBytes(key);
                return hash.ComputeHash(encoding.GetBytes(data));
            }
        }
    }
}
