using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bing.Encryption.Abstractions;
using Bing.Encryption.Check.CRC;
using Bing.Encryption.Core.Internals;

// ReSharper disable once CheckNamespace
namespace Bing.Encryption
{
    /// <summary>
    /// CRC32
    /// </summary>
    public sealed class CRC32 : ICRC<CRC32, uint, int>
    {
        /// <summary>
        /// 校验值
        /// </summary>
        public uint Value { get; set; } = CRC32CheckingProvider.Seed;

        /// <summary>
        /// CRC数据表
        /// </summary>
        private uint[] CRCTable { get; } = CRCTableGenerator.GenerationCRC32Table();

        /// <summary>
        /// 重置
        /// </summary>
        public CRC32 Reset()
        {
            Value = CRC32CheckingProvider.Seed;
            return this;
        }

        /// <summary>
        /// 更新并校验
        /// </summary>
        /// <param name="value">值</param>
        public CRC32 Update(int value)
        {
            Value = CRCTable[(Value ^ value) & 0xFF] ^ (Value >> 8);
            return this;
        }

        /// <summary>
        /// 更新并校验
        /// </summary>
        /// <param name="buffer">数据缓冲区</param>
        /// <param name="offset">偏移量</param>
        /// <param name="count">字节数</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CRC32 Update(byte[] buffer, int offset = 0, int count = 1)
        {
            Checker.Buffer(buffer);
            if (count <= 0)
                count = buffer.Length;
            if (offset < 0 || offset + count > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(offset));
            while (--count >= 0)
                Value = CRCTable[(Value ^ buffer[offset++]) & 0xFF] ^ (Value >> 8);
            return this;
        }

        /// <summary>
        /// 更新并校验
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="count">数量</param>
        public CRC32 Update(Stream stream, long count = -1)
        {
            Checker.Stream(stream);
            if (count <= 0)
                count = long.MaxValue;
            while (--count >= 0)
            {
                var b = stream.ReadByte();
                if (b == -1)
                    break;
                Value = CRCTable[(Value ^ b) & 0xFF] ^ (Value >> 8);
            }
            return this;
        }
    }
}
