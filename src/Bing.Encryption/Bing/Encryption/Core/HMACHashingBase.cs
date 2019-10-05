using System;
using System.Security.Cryptography;
using System.Text;
using Bing.Encryption.Core.Internals;
using Bing.Encryption.Core.Internals.Extensions;

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
        /// <typeparam name="T">密钥哈希算法类型</typeparam>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码</param>
        /// <param name="outType">输出类型</param>
        protected static string Encrypt<T>(string value,string key, Encoding encoding = null, OutType outType = OutType.Hex)
            where T : KeyedHashAlgorithm, new()
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (encoding == null)
                encoding = Encoding.UTF8;
            using (KeyedHashAlgorithm hash=new T())
            {
                hash.Key = encoding.GetBytes(key);
                var result=hash.ComputeHash(encoding.GetBytes(value));

                if (outType == OutType.Base64)
                    return Convert.ToBase64String(result);
                return result.ToHexString();
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <typeparam name="TKeyedHashAlgorithm">密钥哈希算法类型</typeparam>
        /// <param name="data">待加密的数据</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码类型。默认为<see cref="OutType.Hex"/></param>
        protected static HashResult Encrypt<TKeyedHashAlgorithm>(string data, string key,
            Encoding encoding = null)
            where TKeyedHashAlgorithm : KeyedHashAlgorithm, new() =>
            new HashResult(EncryptBytes<TKeyedHashAlgorithm>(data, key, encoding), encoding);

        /// <summary>
        /// 加密
        /// </summary>
        /// <typeparam name="TKeyedHashAlgorithm">密钥哈希算法类型</typeparam>
        /// <param name="data">待加密的数据</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码类型。默认为<see cref="OutType.Hex"/></param>
        protected static byte[] EncryptBytes<TKeyedHashAlgorithm>(string data, string key, Encoding encoding = null)
            where TKeyedHashAlgorithm : KeyedHashAlgorithm, new()
        {
            Checker.Data(data);
            Checker.Key(key);
            encoding = EncodingHelper.Fixed(encoding);
            using (KeyedHashAlgorithm hash=new TKeyedHashAlgorithm())
            {
                hash.Key = encoding.GetBytes(key);
                return hash.ComputeHash(encoding.GetBytes(data));
            }
        }
    }
}
