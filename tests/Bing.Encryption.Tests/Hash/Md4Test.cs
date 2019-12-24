using Xunit;
using Xunit.Abstractions;

namespace Bing.Encryption.Tests.Hash
{
    /// <summary>
    /// MD4测试。基准：https://zh.wikipedia.org/wiki/MD4
    /// </summary>
    public class Md4Test : TestBase
    {
        public Md4Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("image", "0849E54FDE86FE2091E1B8FB5713BE65")]
        [InlineData("", "31d6cfe0d16ae931b73c59d7e0c089c0")]
        [InlineData("The quick brown fox jumps over the lazy cog", "b86e130ce7028da59e672d56ad0113df")]
        [InlineData("The quick brown fox jumps over the lazy dog", "1bee69a46ba811185c194762abaeae90")]
        public void Test_Signature(string plaintext,string ciphertext)
        {
            var signature = MD4HashingProvider.Signature(plaintext).ToLower();
            Output.WriteLine(signature);
            Assert.Equal(ciphertext.ToLower(), signature);
        }
    }
}
