using System;
using Bing.Encryption.Abstractions;
using Bing.Encryption.Core.Internals;

namespace Bing.Encryption.Algorithms
{
    /// <summary>
    /// AutoKey 加密算法。
    /// 更多信息请访问：https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// 参考地址：https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/AutoKey.cs
    /// </summary>
    public sealed class AutoKey : IEncryptionAlgorithm
    {
        /// <summary>
        /// 密钥
        /// </summary>
        private string Key { get; }

        /// <summary>
        /// 初始化一个<see cref="AutoKey"/>类型的实例
        /// </summary>
        /// <param name="key">密钥</param>
        public AutoKey(string key) => Key = key;

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文</param>
        public string Encrypt(string plainText) => ProcessFunc()(Key)(plainText)(EncryptionAlgorithmMode.Encrypt);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipher">密文</param>
        public string Decrypt(string cipher) => ProcessFunc()(Key)(cipher)(EncryptionAlgorithmMode.Decrypt);

        /// <summary>
        /// 处理函数
        /// </summary>
        private static Func<string, Func<string, Func<EncryptionAlgorithmMode, string>>> ProcessFunc() =>
            key => message => mode =>
            {
                var k = DuplicateKeyFunc()(key)(message);
                return AlgorithmHelper.Shift(message, k, mode, AlphabetDictionaryGenerator.Generate());
            };

        /// <summary>
        /// 重复键函数
        /// </summary>
        private static Func<string, Func<string, string>> DuplicateKeyFunc() => key => message =>
        {
            if (key.Length < message.Length)
            {
                var len = message.Length - key.Length;
                for (var i = 0; i < len; i++)
                    key += message[i];
            }
            return key;
        };
    }
}
