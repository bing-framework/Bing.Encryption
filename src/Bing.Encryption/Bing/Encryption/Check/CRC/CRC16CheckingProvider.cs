using System.IO;
using Bing.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Bing.Encryption
{
    /// <summary>
    /// CRC16 校验提供程序
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class CRC16CheckingProvider : CRCCheckingBase<ushort, short>
    {
        /// <summary>
        /// 种子数
        /// </summary>
        public const ushort Seed = 0xFFFF;

        /// <summary>
        /// 初始化一个<see cref="CRC16CheckingProvider"/>类型的实例
        /// </summary>
        private CRC16CheckingProvider() { }

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <param name="offset">偏移量</param>
        /// <param name="count">字节数</param>
        public static ushort Compute(byte[] buffer, int offset = 0, int count = -1) => Compute<CRC16>(buffer, offset, count);

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="count">数量</param>
        public static ushort Compute(Stream stream, int count = -1) => Compute<CRC16>(stream, count);

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="position">流位置</param>
        /// <param name="count">数量</param>
        public static ushort Compute(Stream stream, long position = -1, int count = -1) => Compute<CRC16>(stream, position, count);
    }
}
