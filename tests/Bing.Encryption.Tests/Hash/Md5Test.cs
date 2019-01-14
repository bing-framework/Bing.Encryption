using Bing.Encryption.Hash;
using Xunit;
using Xunit.Abstractions;

namespace Bing.Encryption.Tests.Hash
{
    public class Md5Test:TestBase
    {
        public Md5Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_Bit16()
        {
            var signature = MD5HasingProvider.Signature("image", MD5BitType.L16);
            Assert.Equal("1A988E79EF3F42D7", signature);
        }

        [Fact]
        public void Test_Bit32()
        {
            var signature = MD5HasingProvider.Signature("image", MD5BitType.L32);
            Assert.Equal("78805A221A988E79EF3F42D7C5BFD418", signature);
        }

        [Fact]
        public void Test_Bit64()
        {
            var signature = MD5HasingProvider.Signature("image", MD5BitType.L64);
            Assert.Equal("eIBaIhqYjnnvP0LXxb/UGA==", signature);
        }
    }
}
