using System;
using Xunit;
namespace Playground.UnitTest
{
    public class Test
    {
        [Fact()]
        public void TestMethod()
        {
            Assert.True(true);
        }

		[Fact()]
		public void TestMethod_ShouldFail()
		{
			Assert.True(false);
		}
    }
}
