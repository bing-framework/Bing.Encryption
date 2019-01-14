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

        [Fact]
        public void Test_Sha256_Hex()
        {
            var signature = SHA256HashingProvider.Signature("image");
            Assert.Equal("6105D6CC76AF400325E94D588CE511BE5BFDBB73B437DC51ECA43917D7A43E3D", signature);
        }

        [Fact]
        public void Test_Sha256_Base64()
        {
            var signature = SHA256HashingProvider.Signature("image", OutType.Base64);
            Output.WriteLine(signature);
            Assert.Equal("YQXWzHavQAMl6U1YjOURvlv9u3O0N9xR7KQ5F9ekPj0=", signature);
        }

        [Fact]
        public void Test_Sha384_Hex()
        {
            var signature = SHA384HashingProvider.Signature("image");
            Assert.Equal("7158862BE7FF7D2AE0A585B872F415CF09B7FE8C6CE170EF944061E7788D73C1F5835652D8AFE9939B01905D5AA7C48C", signature);
        }

        [Fact]
        public void Test_Sha384_Base64()
        {
            var signature = SHA384HashingProvider.Signature("image", OutType.Base64);
            Output.WriteLine(signature);
            Assert.Equal("cViGK+f/fSrgpYW4cvQVzwm3/oxs4XDvlEBh53iNc8H1g1ZS2K/pk5sBkF1ap8SM", signature);
        }

        [Fact]
        public void Test_Sha512_Hex()
        {
            var signature = SHA512HashingProvider.Signature("image");
            Assert.Equal("EB31D04DA633DC9F49DFBD66CDB92FBB9B4F9C9BE67914C0209B5DD31CC65A136E1CDCE7D0DB88112E3A759131B9D970CFAAC7EE77CCD620C3DD49043F88958E", signature);
        }

        [Fact]
        public void Test_Sha512_Base64()
        {
            var signature = SHA512HashingProvider.Signature("image", OutType.Base64);
            Output.WriteLine(signature);
            Assert.Equal("6zHQTaYz3J9J371mzbkvu5tPnJvmeRTAIJtd0xzGWhNuHNzn0NuIES46dZExudlwz6rH7nfM1iDD3UkEP4iVjg==", signature);
        }
    }
}
