using Xunit;
using Xunit.Abstractions;

namespace Bing.Encryption.Tests.Symmetric
{
    public class Rc4Test:TestBase
    {
        public Rc4Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_Encrypt_Decrypt()
        {
            var s = RC4EncryptionProvider.Encrypt("image", "jianxuanbing");            
            Assert.Equal("cHNk+Ck=", s);

            var o = RC4EncryptionProvider.Decrypt(s, "jianxuanbing");
            Assert.Equal("image", o);
        }
    }
}
