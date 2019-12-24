using System.IO;

namespace Bing.Encryption.Abstractions
{
    /// <summary>
    /// CRC 循环冗余校验码
    /// </summary>
    /// <typeparam name="TCRC">循环码类型</typeparam>
    /// <typeparam name="T1">数据类型</typeparam>
    /// <typeparam name="T2">数据类型</typeparam>
    // ReSharper disable once InconsistentNaming
    public interface ICRC<TCRC, T1, T2> 
        where TCRC : class, ICRC<TCRC, T1, T2>, new()
        where T1 : struct
        where T2 : struct
    {
        /// <summary>
        /// 校验值
        /// </summary>
        T1 Value { get; set; }

        /// <summary>
        /// 重置
        /// </summary>
        TCRC Reset();

        /// <summary>
        /// 更新并校验
        /// </summary>
        /// <param name="value">值</param>
        TCRC Update(T2 value);

        /// <summary>
        /// 更新并校验
        /// </summary>
        /// <param name="buffer">数据缓冲区</param>
        /// <param name="offset">偏移量</param>
        /// <param name="count">字节数</param>
        TCRC Update(byte[] buffer, int offset = 0, int count = 1);

        /// <summary>
        /// 更新并校验
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="count">数量</param>
        TCRC Update(Stream stream, long count = -1);
    }
}
