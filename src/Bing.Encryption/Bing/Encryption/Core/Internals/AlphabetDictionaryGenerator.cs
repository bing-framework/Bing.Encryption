using System;
using System.Collections.Generic;

namespace Bing.Encryption.Core.Internals
{
    /// <summary>
    /// 字母字典生成器
    /// </summary>
    internal static class AlphabetDictionaryGenerator
    {
        /// <summary>
        /// 字母字典缓存
        /// </summary>
        private static Dictionary<char, int> AlphabetCache { get; }

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static AlphabetDictionaryGenerator() => AlphabetCache = GenerateFunc()();

        /// <summary>
        /// 生成字母字典
        /// </summary>
        public static Dictionary<char, int> Generate() => AlphabetCache;

        /// <summary>
        /// 生成新的字母字典实例
        /// </summary>
        public static Dictionary<char, int> GenerateNewInstance() => GenerateFunc()();

        /// <summary>
        /// 生成函数
        /// </summary>
        private static Func<Dictionary<char, int>> GenerateFunc() => () =>
        {
            var alphabet = new Dictionary<char, int>();
            var c = 'a';
            for (var i = 0; i < 26; i++)
                alphabet.Add(c, i);
            return alphabet;
        };
    }
}
