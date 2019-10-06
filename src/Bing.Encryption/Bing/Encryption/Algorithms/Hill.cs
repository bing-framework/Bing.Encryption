using System;
using System.Text;
using Bing.Encryption.Abstractions;
using Bing.Encryption.Core.Internals;

namespace Bing.Encryption.Algorithms
{
    /// <summary>
    /// AutoKey 加密算法。
    /// 更多信息请访问：https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// 参考地址：https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/Hill.cs
    /// </summary>
    public sealed class Hill : IEncryptionAlgorithm
    {
        /// <summary>
        /// 密钥
        /// </summary>
        private int[,] Key { get; }

        /// <summary>
        /// 初始化一个<see cref="Hill"/>类型的实例
        /// </summary>
        /// <param name="matrix">矩阵密钥</param>
        public Hill(int[,] matrix) => Key = matrix;

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文</param>
        public string Encrypt(string plainText)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipher">密文</param>
        public string Decrypt(string cipher)
        {
            throw new NotImplementedException();
        }

        private static Func<int[,], Func<string, Func<EncryptionAlgorithmMode, string>>> ProcessFunc() => key =>
            message =>
                mode =>
                {
                    var sb = new StringBuilder();

                    return sb.ToString();
                };
    }
}
