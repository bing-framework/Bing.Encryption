using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bing.Encryption.Core.Internals
{
    /// <summary>
    /// 算法操作辅助类
    /// </summary>
    internal static class AlgorithmHelper
    {
        /// <summary>
        /// 转移
        /// </summary>
        /// <param name="token">令牌</param>
        /// <param name="key">密钥</param>
        /// <param name="mode">加密算法模式</param>
        /// <param name="alphabetSortedDict">字母排序字典</param>
        internal static string Shift(string token, string key, EncryptionAlgorithmMode mode, Dictionary<char, int> alphabetSortedDict)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < token.Length; i++)
            {
                var resPosition = GetAlphabetPositionFunc()
                        (alphabetSortedDict[token[i]]) /*文本位置*/
                        (alphabetSortedDict[key[i]]) /*密钥位置*/
                        (mode); /*加密算法模式*/
                sb.Append(alphabetSortedDict.Keys.ElementAt(resPosition));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取字母位置函数
        /// </summary>
        internal static Func<int, Func<int, Func<EncryptionAlgorithmMode, int>>> GetAlphabetPositionFunc() =>
            textPosition => keyPosition => mode =>
            {
                switch (mode)
                {
                    case EncryptionAlgorithmMode.Encrypt:
                        return (textPosition + keyPosition) % 26;
                    case EncryptionAlgorithmMode.Decrypt:
                        var result = textPosition - keyPosition;
                        return result < 0 ? result + 26 : result;
                    default:
                        return 0;
                }
            };
    }
}
