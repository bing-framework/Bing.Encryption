using System;
using System.IO;
using Bing.Encryption.Abstractions;
using Bing.Encryption.Core.Internals;

// ReSharper disable once CheckNamespace
namespace Bing.Encryption
{
    /// <summary>
    /// CRC16
    /// </summary>
    public sealed class CRC16:ICRC<CRC16,ushort,short>
    {
        /// <summary>
        /// 校验值
        /// </summary>
        public ushort Value { get; set; } = CRC16CheckingProvider.Seed;

        /// <summary>
        /// CRC数据表
        /// </summary>
        private ushort[] CRCTable { get; } = CRCTableGenerator.GenerationCRC16Table();

        /// <summary>
        /// 重置
        /// </summary>
        public CRC16 Reset()
        {
            Value = CRC16CheckingProvider.Seed;
            return this;
        }

        /// <summary>
        /// 更新并校验
        /// </summary>
        /// <param name="value">值</param>
        public CRC16 Update(short value)
        {
            Value = (ushort) ((Value << 8) ^ CRCTable[(Value >> 8) ^ value]);
            return this;
        }

        /// <summary>
        /// 更新并校验
        /// </summary>
        /// <param name="buffer">数据缓冲区</param>
        /// <param name="offset">偏移量</param>
        /// <param name="count">字节数</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CRC16 Update(byte[] buffer, int offset = 0, int count = 1)
        {
            Checker.Buffer(buffer);
            if (count <= 0)
                count = buffer.Length;
            if (offset < 0 || offset + count > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(offset));
            Value ^= Value;
            for (var i = 0; i < count; i++)
                Value = (ushort) ((Value << 8) ^ CRCTable[(Value >> 8) ^ buffer[offset + i] & 0xFF]);
            return this;
        }

        /// <summary>
        /// 更新并校验
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="count">数量</param>
        public CRC16 Update(Stream stream, long count = -1)
        {
            Checker.Stream(stream);
            if (count <= 0)
                count = long.MaxValue;
            while (--count>=0)
            {
                var b = stream.ReadByte();
                if(b==-1)
                    break;
                Value ^= (byte) b;
                for (var i = 0; i < 8; i++)
                {
                    if ((Value & 0x0001) != 0)
                        Value = (ushort) ((Value >> 1) ^ 0xa001);
                    else
                        Value = (ushort) (Value >> 1);
                }
            }
            return this;
        }
    }
}
