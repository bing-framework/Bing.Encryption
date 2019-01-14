using System;
using System.Collections.Generic;
using System.Text;
using Bing.Encryption.Core;
using Xunit;
using Xunit.Abstractions;

namespace Bing.Encryption.Tests.Hash
{
    public class ShaTest:TestBase
    {
        public ShaTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_Sha1_Hex()
        {
            var signature = SHA1HashingProvider.Signature("image");
            Assert.Equal("0E76292794888D4F1FA75FB3AFF4CA27C58F56A6", signature);
        }

        [Fact]
        public void Test_Sha1_Base64()
        {
            var signature = SHA1HashingProvider.Signature("image", OutType.Base64);
            Assert.Equal("DnYpJ5SIjU8fp1+zr/TKJ8WPVqY=", signature);
        }
    }
}
