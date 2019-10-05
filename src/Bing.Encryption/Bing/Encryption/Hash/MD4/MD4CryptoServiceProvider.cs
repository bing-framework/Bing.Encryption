using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

// ReSharper disable once CheckNamespace
namespace Bing.Encryption
{
    /// <summary>
    /// MD4 加密服务提供程序
    /// 参考：https://bitlush.com/blog/md4-hash-algorithm-in-c-sharp
    /// </summary>
    public sealed class MD4CryptoServiceProvider : HashAlgorithm
    {
        private uint _a;
        private uint _b;
        private uint _c;
        private uint _d;
        private readonly uint[] _x;
        private int _bytesProcessed;

        /// <summary>
        /// 初始化一个<see cref="MD4CryptoServiceProvider"/>类型的实例
        /// </summary>
        public MD4CryptoServiceProvider()
        {
            _x = new uint[16];
            Initialize();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Initialize()
        {
            _a = 0x67452301;
            _b = 0xefcdab89;
            _c = 0x98badcfe;
            _d = 0x10325476;

            _bytesProcessed = 0;
        }

        /// <summary>
        /// 核心Hash算法
        /// </summary>
        protected override void HashCore(byte[] array, int offset, int length)
        {
            ProcessMessage(Bytes(array, offset, length));
        }

        /// <summary>
        /// Hash完成
        /// </summary>
        /// <returns></returns>
        protected override byte[] HashFinal()
        {
            try
            {
                ProcessMessage(Padding());
                return new[] {_a, _b, _c, _d}.SelectMany(word => Bytes(word)).ToArray();
            }
            finally
            {
                Initialize();
            }
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        private void ProcessMessage(IEnumerable<byte> bytes)
        {
            foreach (var b in bytes)
            {
                int c = _bytesProcessed & 63;
                int i = c >> 2;
                int s = (c & 3) << 3;

                _x[i] = (_x[i] & ~((uint) 255 << s)) | ((uint) b << s);

                if (c == 63)
                {
                    Process16WordBlock();
                }

                _bytesProcessed++;
            }
        }

        /// <summary>
        /// 获取字节数组
        /// </summary>
        private static IEnumerable<byte> Bytes(byte[] bytes, int offset, int length)
        {
            for (var i = offset; i < length; i++)
            {
                yield return bytes[i];
            }
        }

        /// <summary>
        /// 获取字节数组
        /// </summary>
        private IEnumerable<byte> Bytes(uint word)
        {
            yield return (byte) (word & 255);
            yield return (byte) ((word >> 8) & 255);
            yield return (byte) ((word >> 16) & 255);
            yield return (byte) ((word >> 24) & 255);
        }

        /// <summary>
        /// 重复
        /// </summary>
        private IEnumerable<byte> Repeat(byte value, int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return value;
            }
        }

        /// <summary>
        /// 填充
        /// </summary>
        /// <returns></returns>
        private IEnumerable<byte> Padding()
        {
            return Repeat(128, 1)
                .Concat(Repeat(0, ((_bytesProcessed + 8) & 0x7fffffc0) + 55 - _bytesProcessed))
                .Concat(Bytes((uint) _bytesProcessed << 3))
                .Concat(Repeat(0, 4));
        }

        /// <summary>
        /// 处理16个块
        /// </summary>
        private void Process16WordBlock()
        {
            uint aa = _a;
            uint bb = _b;
            uint cc = _c;
            uint dd = _d;

            foreach (int k in new[] { 0, 4, 8, 12 })
            {
                aa = Round1Operation(aa, bb, cc, dd, _x[k], 3);
                dd = Round1Operation(dd, aa, bb, cc, _x[k + 1], 7);
                cc = Round1Operation(cc, dd, aa, bb, _x[k + 2], 11);
                bb = Round1Operation(bb, cc, dd, aa, _x[k + 3], 19);
            }

            foreach (int k in new[] { 0, 1, 2, 3 })
            {
                aa = Round2Operation(aa, bb, cc, dd, _x[k], 3);
                dd = Round2Operation(dd, aa, bb, cc, _x[k + 4], 5);
                cc = Round2Operation(cc, dd, aa, bb, _x[k + 8], 9);
                bb = Round2Operation(bb, cc, dd, aa, _x[k + 12], 13);
            }

            foreach (int k in new[] { 0, 2, 1, 3 })
            {
                aa = Round3Operation(aa, bb, cc, dd, _x[k], 3);
                dd = Round3Operation(dd, aa, bb, cc, _x[k + 8], 9);
                cc = Round3Operation(cc, dd, aa, bb, _x[k + 4], 11);
                bb = Round3Operation(bb, cc, dd, aa, _x[k + 12], 15);
            }

            unchecked
            {
                _a += aa;
                _b += bb;
                _c += cc;
                _d += dd;
            }
        }

        /// <summary>
        /// 轮操作处理
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private static uint ROL(uint value, int numberOfBits)
        {
            return (value << numberOfBits) | (value >> (32 - numberOfBits));
        }

        /// <summary>
        /// 第1轮操作
        /// </summary>
        private static uint Round1Operation(uint a, uint b, uint c, uint d, uint xk, int s)
        {
            unchecked
            {
                return ROL(a + ((b & c) | (~b & d)) + xk, s);
            }
        }

        /// <summary>
        /// 第2轮操作
        /// </summary>
        private static uint Round2Operation(uint a, uint b, uint c, uint d, uint xk, int s)
        {
            unchecked
            {
                return ROL(a + ((b & c) | (b & d) | (c & d)) + xk + 0x5a827999, s);
            }
        }

        /// <summary>
        /// 第3轮操作
        /// </summary>
        private static uint Round3Operation(uint a, uint b, uint c, uint d, uint xk, int s)
        {
            unchecked
            {
                return ROL(a + (b ^ c ^ d) + xk + 0x6ed9eba1, s);
            }
        }
    }
}
