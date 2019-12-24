using System;
using System.Security.Cryptography;
using System.Text;
using Bing.Encryption.Core.Internals;
using Bing.Encryption.Core.Internals.Extensions;

namespace Bing.Encryption.Core
{
    /// <summary>
    /// SHA哈希加密基类
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public abstract class SHAHashingBase
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <typeparam name="THashAlgorithm">哈希算法类型</typeparam>
        /// <param name="data">待加密的数据</param>
        /// <param name="encoding">编码类型。默认为<see cref="Encoding.UTF8"/></param>
        protected static HashResult Encrypt<THashAlgorithm>(string data, Encoding encoding = null)
            where THashAlgorithm : HashAlgorithm, new() =>
            new HashResult(EncryptBytes<THashAlgorithm>(data, encoding), encoding);

        /// <summary>
        /// 加密
        /// </summary>
        /// <typeparam name="THashAlgorithm">哈希算法类型</typeparam>
        /// <param name="data">待加密的数据</param>
        /// <param name="encoding">编码类型。默认为<see cref="Encoding.UTF8"/></param>
        protected static byte[] EncryptBytes<THashAlgorithm>(string data, Encoding encoding = null)
            where THashAlgorithm : HashAlgorithm, new()
        {
            Checker.Data(data);
            encoding = EncodingHelper.Fixed(encoding);
            using (HashAlgorithm hash = new THashAlgorithm())
                return hash.ComputeHash(encoding.GetBytes(data));
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <typeparam name="T">哈希算法类型</typeparam>
        /// <param name="value">待加密的值</param>
        /// <param name="encoding">编码</param>
        /// <param name="outType">输出类型</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected static string Encrypt<T>(string value, Encoding encoding = null, OutType outType = OutType.Hex)
            where T : HashAlgorithm, new()
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            encoding = EncodingHelper.Fixed(encoding);
            using (HashAlgorithm hash = new T())
            {
                var bytes = hash.ComputeHash(encoding.GetBytes(value));
                return outType == OutType.Base64 ? Convert.ToBase64String(bytes) : bytes.ToHexString();
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <typeparam name="T">哈希算法类型</typeparam>
        /// <param name="value">待加密的值</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected static byte[] Encrypt<T>(byte[] value) where T : HashAlgorithm, new()
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            using (HashAlgorithm hash = new T())
                return hash.ComputeHash(value);
        }
    }
}