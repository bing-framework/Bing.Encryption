using System.IO;

namespace Bing.Encryption.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCRC"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public interface ICRC<TCRC, T1, T2> 
        where TCRC : class, ICRC<TCRC, T1, T2>, new()
        where T1 : struct
        where T2 : struct
    {
        /// <summary>
        /// 
        /// </summary>
        T1 Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        TCRC Reset();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        TCRC Update(T2 value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        TCRC Update(byte[] buffer, int offset = 0, int count = 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        TCRC Stream(Stream stream, long count = -1);
    }
}
