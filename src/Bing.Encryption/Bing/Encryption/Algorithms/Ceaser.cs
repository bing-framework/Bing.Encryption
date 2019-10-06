using System;
using System.Linq;
using System.Text;
using Bing.Encryption.Abstractions;
using Bing.Encryption.Core.Internals;

namespace Bing.Encryption.Algorithms
{
    /// <summary>
    /// Ceaser 加密算法。
    /// 更多信息请访问：https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// 参考地址：https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/AutoKey.cs
    /// </summary>
    public sealed class Ceaser : IEncryptionAlgorithm
    {
        /// <summary>
        /// 密钥
        /// </summary>
        private int Key { get; }

        /// <summary>
        /// 初始化一个<see cref="Ceaser"/>类型的实例
        /// </summary>
        /// <param name="key">密钥</param>
        public Ceaser(int key) => Key = key;

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
        private static Func<int, Func<string, Func<EncryptionAlgorithmMode, string>>> ProcessFunc() => key => message =>
            mode =>
            {
                var sb = new StringBuilder();
                var alphabet = AlphabetDictionaryGenerator.Generate();
                foreach (var c in message)
                {
                    var res = AlgorithmHelper.GetAlphabetPositionFunc()
                        (alphabet[c]) /*字符位置*/
                        (key)
                        (mode); /*加密算法模式*/
                    sb.Append(alphabet.Keys.ElementAt(res % 26));
                }
                return sb.ToString();
            };
    }
}
