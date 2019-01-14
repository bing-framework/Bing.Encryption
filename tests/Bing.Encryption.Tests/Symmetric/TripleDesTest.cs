using Xunit;
using Xunit.Abstractions;

namespace Bing.Encryption.Tests.Symmetric
{
    public class TripleDesTest:TestBase
    {
        public TripleDesTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_Encrypt_Decrypt_L128()
        {            
            var s1 = TripleDESEncryptionProvider.Encrypt("仙剑蜀山", "jianxuanbing", "12345678", keySize: TripleDESKeySizeType.L128);
            var o1 = TripleDESEncryptionProvider.Decrypt(s1, "jianxuanbing", "12345678", keySize: TripleDESKeySizeType.L128);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_Decrypt_L128_WithSalt()
        {
            var s1 = TripleDESEncryptionProvider.Encrypt("仙剑蜀山", "jianxuanbing", "12345678", "66666666",
                keySize: TripleDESKeySizeType.L128);
            var o1 = TripleDESEncryptionProvider.Decrypt(s1, "jianxuanbing", "12345678", "66666666", keySize: TripleDESKeySizeType.L128);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_Decrypt_L192()
        {
            var s1 = TripleDESEncryptionProvider.Encrypt("仙剑蜀山", "jianxuanbing", "12345678", keySize: TripleDESKeySizeType.L192);
            var o1 = TripleDESEncryptionProvider.Decrypt(s1, "jianxuanbing", "12345678", keySize: TripleDESKeySizeType.L192);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_Decrypt_L192_WithSalt()
        {
            var s1 = TripleDESEncryptionProvider.Encrypt("仙剑蜀山", "jianxuanbing", "12345678", "66666666",
                keySize: TripleDESKeySizeType.L192);
            var o1 = TripleDESEncryptionProvider.Decrypt(s1, "jianxuanbing", "12345678", "66666666", keySize: TripleDESKeySizeType.L192);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_Decrypt_AutoCreateKey_L128()
        {
            var key = TripleDESEncryptionProvider.CreateKey(TripleDESKeySizeType.L128);
            var s1 = TripleDESEncryptionProvider.Encrypt("仙剑蜀山", key.Key, key.IV, keySize: TripleDESKeySizeType.L128);
            var o1 = TripleDESEncryptionProvider.Decrypt(s1, key.Key, key.IV, keySize: TripleDESKeySizeType.L128);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_Decrypt_AutoCreateKey_L128_WithSalt()
        {
            var key = TripleDESEncryptionProvider.CreateKey(TripleDESKeySizeType.L128);
            var s1 = TripleDESEncryptionProvider.Encrypt("仙剑蜀山", key.Key, key.IV, "66666666",
                keySize: TripleDESKeySizeType.L128);
            var o1 = TripleDESEncryptionProvider.Decrypt(s1, key.Key, key.IV, "66666666", keySize: TripleDESKeySizeType.L128);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_Decrypt_AutoCreateKey_L192()
        {
            var key = TripleDESEncryptionProvider.CreateKey(TripleDESKeySizeType.L128);
            var s1 = TripleDESEncryptionProvider.Encrypt("仙剑蜀山", key.Key, key.IV, keySize: TripleDESKeySizeType.L128);
            var o1 = TripleDESEncryptionProvider.Decrypt(s1, key.Key, key.IV, keySize: TripleDESKeySizeType.L128);
            Assert.Equal("仙剑蜀山", o1);
        }

        [Fact]
        public void Test_Encrypt_Decrypt_AutoCreateKey_L192_WithSalt()
        {
            var key = TripleDESEncryptionProvider.CreateKey(TripleDESKeySizeType.L192);
            var s1 = TripleDESEncryptionProvider.Encrypt("仙剑蜀山", key.Key, key.IV, "66666666",
                keySize: TripleDESKeySizeType.L192);
            var o1 = TripleDESEncryptionProvider.Decrypt(s1, key.Key, key.IV, "66666666", keySize: TripleDESKeySizeType.L192);
            Assert.Equal("仙剑蜀山", o1);
        }
    }
}
