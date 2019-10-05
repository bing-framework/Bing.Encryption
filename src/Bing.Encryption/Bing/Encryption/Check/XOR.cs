using System;
using System.Text;
using Bing.Encryption.Core.Internals;

// ReSharper disable once CheckNamespace
namespace Bing.Encryption
{
    /// <summary>
    /// XOR(异或)
    /// </summary>
    public static class XOR
    {
        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="value">待计算的值</param>
        /// <param name="encoding">编码类型，默认为<see cref="Encoding.UTF8"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static byte Compute(string value, Encoding encoding = null)
        {
            encoding = EncodingHelper.Fixed(encoding);
            var buffer = encoding.GetBytes(value);
            return Compute(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <param name="index">索引值</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static byte Compute(byte[] buffer, int index = 0) => Compute(buffer, index, buffer.Length);

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <param name="index">索引值</param>
        /// <param name="length">长度</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static byte Compute(byte[] buffer, int index, int length)
        {
            if (buffer == null || buffer.Length == 0)
                throw new ArgumentNullException(nameof(buffer));
            var bufferLength = buffer.Length;
            if (index > bufferLength - 1 || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (length > bufferLength || length < 1)
                throw new ArgumentOutOfRangeException(nameof(length));
            if (index + length > bufferLength)
                throw new ArgumentOutOfRangeException($"{nameof(index)} & {nameof(length)}");
            byte output = 0;
            for (var i = index; i < length; i++)
                output ^= buffer[i];
            return output;
        }
    }
}
