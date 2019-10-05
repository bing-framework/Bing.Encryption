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
    }
}
