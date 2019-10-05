using System;
using System.IO;

namespace Bing.Encryption.Core.Internals
{
    /// <summary>
    /// 检查器
    /// </summary>
    internal static class Checker
    {
        /// <summary>
        /// 数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Data(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));
        }

        /// <summary>
        /// 密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Password(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
        }

        /// <summary>
        /// 向量
        /// </summary>
        /// <param name="iv">向量</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void IV(string iv)
        {
            if (string.IsNullOrEmpty(iv))
                throw new ArgumentNullException(nameof(iv));
        }

        /// <summary>
        /// 密钥
        /// </summary>
        /// <typeparam name="T">密钥类型</typeparam>
        /// <param name="key">密钥</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Key<T>(T key) where T : class
        {
            switch (key)
            {
                case string strKey when string.IsNullOrEmpty(strKey):
                    throw new ArgumentNullException(nameof(key));
                case null:
                    throw new ArgumentNullException(nameof(key));
            }
        }

        /// <summary>
        /// 字节数组
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Buffer(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
        }

        /// <summary>
        /// 流
        /// </summary>
        /// <param name="stream">流</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Stream(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="nameOfFilePath">文件路径名称</param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void File(string filePath, string nameOfFilePath = null)
        {
            nameOfFilePath = string.IsNullOrEmpty(nameOfFilePath) ? nameof(filePath) : nameOfFilePath;
            if (!System.IO.File.Exists(filePath))
                throw new FileNotFoundException(nameOfFilePath);
        }
    }
}
