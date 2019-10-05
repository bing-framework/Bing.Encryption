using System.IO;
using Bing.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Bing.Encryption
{
    /// <summary>
    /// CRC32 校验提供程序
    /// </summary>
    public sealed class CRC32CheckingProvider : CRCCheckingBase<uint, int>
    {
        /// <summary>
        /// 种子数
        /// </summary>
        public const uint Seed = 0xFFFFFFFF;

        /// <summary>
        /// 初始化一个<see cref="CRC32CheckingProvider"/>类型的实例
        /// </summary>
        private CRC32CheckingProvider() { }

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <param name="offset">偏移量</param>
        /// <param name="count">字节数</param>
        public static uint Compute(byte[] buffer, int offset = 0, int count = -1) => Compute<CRC32>(buffer, offset, count);

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="count">数量</param>
        public static uint Compute(Stream stream, int count = -1) => Compute<CRC32>(stream, count);

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="position">流位置</param>
        /// <param name="count">数量</param>
        public static uint Compute(Stream stream, long position = -1, int count = -1) => Compute<CRC32>(stream, position, count);
    }
}
