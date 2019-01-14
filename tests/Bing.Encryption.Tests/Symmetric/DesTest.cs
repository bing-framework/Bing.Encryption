using Xunit;
using Xunit.Abstractions;

namespace Bing.Encryption.Tests.Symmetric
{
    public class DesTest:TestBase
    {
        public DesTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_Encrypt_Decrypt()
        {
            var s = DESEncryptionProvider.Encrypt("image", "jianxuanbing", "123456");
            Output.WriteLine(s);
            Assert.Equal("W1qT5HubZGo=", s);

            var o = DESEncryptionProvider.Decrypt(s, "jianxuanbing", "123456");
            Assert.Equal("image", o);
        }

        [Fact]
        public void Test_Encrypt_Decrypt_WithSalt()
        {
            var s = DESEncryptionProvider.Encrypt("image", "jianxuanbing", "123456", "66666666");
            Output.WriteLine(s);
            Assert.Equal("mhYoC9zYD14=", s);

            var o = DESEncryptionProvider.Decrypt(s, "jianxuanbing", "123456", "66666666");
            Assert.Equal("image", o);
        }

        [Fact]
        public void Test_Encrypt_Decrypt_AutoCreateKey()
        {
            var key = DESEncryptionProvider.CreateKey();
            var s = DESEncryptionProvider.Encrypt("image", key.Key, key.IV);
            var o = DESEncryptionProvider.Decrypt(s, key.Key, key.IV);
            Assert.Equal("image", o);
        }

        [Fact]
        public void Test_Encrypt_Decrypt_AutoCreateKey_WithSalt()
        {
            var key = DESEncryptionProvider.CreateKey();
            var s = DESEncryptionProvider.Encrypt("image", key.Key, key.IV, "88888888");
            var o = DESEncryptionProvider.Decrypt(s, key.Key, key.IV, "88888888");
            Assert.Equal("image", o);
        }
    }
}
