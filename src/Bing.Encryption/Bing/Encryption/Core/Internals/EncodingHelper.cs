using System.Text;

namespace Bing.Encryption.Core.Internals
{
    /// <summary>
    /// 编码操作辅助类
    /// </summary>
    internal static class EncodingHelper
    {
        /// <summary>
        /// 修正
        /// </summary>
        /// <param name="encoding">编码</param>
        public static Encoding Fixed(Encoding encoding) => encoding ?? Encoding.UTF8;
    }
}
