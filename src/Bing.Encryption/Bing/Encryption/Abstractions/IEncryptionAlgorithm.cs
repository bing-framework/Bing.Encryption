namespace Bing.Encryption.Abstractions
{
    /// <summary>
    /// 加密算法
    /// </summary>
    public interface IEncryptionAlgorithm
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文</param>
        string Encrypt(string plainText);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipher">密文</param>
        string Decrypt(string cipher);
    }
}
