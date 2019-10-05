using Xunit;
using Xunit.Abstractions;

namespace Bing.Encryption.Tests.Hash
{
    public class HmacTest:TestBase
    {
        public HmacTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_HmacMd5()
        {
            var signature = HMACMD5HashingProvider.Signature("image", "jianxuanbing");
            Output.WriteLine(signature.HexUpperString);
            Assert.Equal("EC2D786F467FF87934F9C6D4D64469CE", signature.HexUpperString);
        }

        [Fact]
        public void Test_HmacSha1()
        {
            var signature = HMACSHA1HashingProvider.Signature("image", "jianxuanbing");
            Output.WriteLine(signature);
            Assert.Equal("8D37923C16B438FC9B29462CB93723ADB46EF14A", signature);
        }

        [Fact]
        public void Test_HmacSha256()
        {
            var signature = HMACSHA256HashingProvider.Signature("image", "jianxuanbing");
            Output.WriteLine(signature);
            Assert.Equal("0786D94B4433473587B2DC8ED9E0813CC714A953B2604CE69EBBA9BCDD62CB2E", signature);
        }

        [Fact]
        public void Test_HmacSha384()
        {
            var signature = HMACSHA384HashingProvider.Signature("image", "jianxuanbing");
            Output.WriteLine(signature);
            Assert.Equal("AE705092BCE33068C49046E5BFD5AF1BBC5E7D5BCC20002D9597638C8E070885164377413EC14D76AD47702B720047B8", signature);
        }

        [Fact]
        public void Test_HmacSha512()
        {
            var signature = HMACSHA512HashingProvider.Signature("image", "jianxuanbing");
            Output.WriteLine(signature);
            Assert.Equal("4CE29097986F619D54F0C7F31BEE2C1667B95781CA42A3D0C97B18DB32FD0EA36EDB1CEB5EE53493A36BA6613C17068918FAFC28B05CBD180D4D5A11CFD30952", signature);
        }
    }
}
