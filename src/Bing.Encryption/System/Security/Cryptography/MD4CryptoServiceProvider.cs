using System;
using System.Collections.Generic;
using System.Text;

namespace System.Security.Cryptography
{
    /// <summary>
    /// MD4 加密服务提供程序
    /// </summary>
    public sealed class MD4CryptoServiceProvider:HashAlgorithm
    {
        /// <summary>When overridden in a derived class, routes data written to the object into the hash algorithm for computing the hash.</summary>
        /// <param name="array">The input to compute the hash code for.</param>
        /// <param name="ibStart">The offset into the byte array from which to begin using data.</param>
        /// <param name="cbSize">The number of bytes in the byte array to use as data.</param>
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>When overridden in a derived class, finalizes the hash computation after the last data is processed by the cryptographic stream object.</summary>
        /// <returns>The computed hash code.</returns>
        protected override byte[] HashFinal()
        {
            throw new NotImplementedException();
        }

        /// <summary>Initializes an implementation of the <see cref="T:System.Security.Cryptography.HashAlgorithm"></see> class.</summary>
        public override void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
