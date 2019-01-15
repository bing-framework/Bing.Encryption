using Xunit;
using Xunit.Abstractions;

namespace Bing.Encryption.Tests.Hash
{
    public class Md4Test:TestBase
    {
        public Md4Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test_Signature()
        {
            var signature = MD4HashingProvider.Signature("image");
            Output.WriteLine(signature);
            Assert.Equal("0849E54FDE86FE2091E1B8FB5713BE65", signature);
        }
    }
}
