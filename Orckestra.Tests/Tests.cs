using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Orckestra.Tests
{
    public class Tests
    {
        [Theory]
        [InlineData("nondateval", false)]
        [InlineData("1900-01-30", false)]
        [InlineData("1900.01.30", false)]
        [InlineData("01301900", false)]
        [InlineData("1900-01-1", false)]

        [InlineData("1900/01/30", true)]
        [InlineData("30/01/1900", true)]
        [InlineData("01-30-1900", true)]
        public void ChangeDateFormat_Returns_Valid_Values(string input, bool valid)
        {
            IEnumerable<string> output = Solution.ChangeDateFormat(new[] { input });

            int count = output.Count();
            Assert.True(count < 2);
            if (count == 0)
            {
                Assert.False(valid);
            }
            else
            {
                Assert.True(valid);
            }
        }

        [Theory]
        [InlineData("rwxr-x-w-", "752")]
        [InlineData("rwxr-x---", "750")]
        [InlineData("-------x-", "001")]
        public void SymbolicToOctal(string input, string expectedOutput)
        {
            string output = Solution.SymbolicToOctal(input);
            Assert.Equal(expectedOutput, output);
        }
    }
}
