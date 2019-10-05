using System.IO;
using Bing.Encryption.Abstractions;

namespace Bing.Encryption.Core
{
    /// <summary>
    /// CRC 检查基类
    /// </summary>
    /// <typeparam name="T1">数据类型</typeparam>
    /// <typeparam name="T2">数据类型</typeparam>
    public abstract class CRCCheckingBase<T1, T2>
        where T1 : struct
        where T2 : struct
    {
        /// <summary>
        /// 计算
        /// </summary>
        /// <typeparam name="TCRC">CRC类型</typeparam>
        /// <param name="buffer">字节数组</param>
        /// <param name="offset">偏移量</param>
        /// <param name="count">字节数</param>
        protected static T1 Compute<TCRC>(byte[] buffer, int offset = 0, int count = -1)
            where TCRC : class, ICRC<TCRC, T1, T2>, new()
        {
            var crc = new TCRC();
            crc.Update(buffer, offset, count);
            return crc.Value;
        }

        /// <summary>
        /// 计算
        /// </summary>
        /// <typeparam name="TCRC">CRC类型</typeparam>
        /// <param name="stream">流</param>
        /// <param name="count">数量</param>
        protected static T1 Compute<TCRC>(Stream stream, int count = -1)
            where TCRC : class, ICRC<TCRC, T1, T2>, new()
        {
            var crc = new TCRC();
            crc.Update(stream, count);
            return crc.Value;
        }

        /// <summary>
        /// 计算
        /// </summary>
        /// <typeparam name="TCRC">CRC类型</typeparam>
        /// <param name="stream">流</param>
        /// <param name="position">流位置</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        protected static T1 Compute<TCRC>(Stream stream, long position = -1, int count = -1)
            where TCRC : class, ICRC<TCRC, T1, T2>, new()
        {
            if (position >= 0)
            {
                if (count > 0)
                    count = -count;
                count += (int) (stream.Position - position);
                if (count == 0)
                    return default(T1);
                stream.Position = position;
            }

            var crc = new TCRC();
            crc.Update(stream, count);
            return crc.Value;
        }
    }
}
