using Xunit;
using Xunit.Abstractions;

namespace Bing.Encryption.Tests.Symmetric
{
    public class AesTest:TestBase
    {
        public AesTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_Encrypt_L128()
        {
            var key = AESEncryptionProvider.CreateKey(AESKeySizeType.L128);
            var s1 = AESEncryptionProvider.Encrypt("仙剑蜀山", key.Key, key.IV, keySize: AESKeySizeType.L128);
            var o1 = AESEncryptionProvider.Decrypt(s1, key.Key, key.IV, keySize: AESKeySizeType.L128);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_L192()
        {
            var key = AESEncryptionProvider.CreateKey(AESKeySizeType.L192);
            var s1 = AESEncryptionProvider.Encrypt("仙剑蜀山", key.Key, key.IV, keySize: AESKeySizeType.L192);
            var o1 = AESEncryptionProvider.Decrypt(s1, key.Key, key.IV, keySize: AESKeySizeType.L192);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_L256()
        {
            var key = AESEncryptionProvider.CreateKey(AESKeySizeType.L256);
            var s1 = AESEncryptionProvider.Encrypt("仙剑蜀山", key.Key, key.IV, keySize: AESKeySizeType.L256);
            var o1 = AESEncryptionProvider.Decrypt(s1, key.Key, key.IV, keySize: AESKeySizeType.L256);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_L128_WithSalt()
        {
            var key = AESEncryptionProvider.CreateKey(AESKeySizeType.L128);
            var s1 = AESEncryptionProvider.Encrypt("仙剑蜀山", key.Key, key.IV,"12345678", keySize: AESKeySizeType.L128);
            var o1 = AESEncryptionProvider.Decrypt(s1, key.Key, key.IV, "12345678", keySize: AESKeySizeType.L128);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_L192_WithSalt()
        {
            var key = AESEncryptionProvider.CreateKey(AESKeySizeType.L192);
            var s1 = AESEncryptionProvider.Encrypt("仙剑蜀山", key.Key, key.IV, "12345678", keySize: AESKeySizeType.L192);
            var o1 = AESEncryptionProvider.Decrypt(s1, key.Key, key.IV, "12345678", keySize: AESKeySizeType.L192);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_L256_WithSalt()
        {
            var key = AESEncryptionProvider.CreateKey(AESKeySizeType.L256);
            var s1 = AESEncryptionProvider.Encrypt("仙剑蜀山", key.Key, key.IV, "12345678", keySize: AESKeySizeType.L256);
            var o1 = AESEncryptionProvider.Decrypt(s1, key.Key, key.IV, "12345678", keySize: AESKeySizeType.L256);
            Assert.Equal("仙剑蜀山", o1);
        }
    }
}
