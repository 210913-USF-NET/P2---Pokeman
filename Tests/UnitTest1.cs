using System;
using Xunit;
using Models;


namespace Tests
{
    public class ModelTests
    {
        [Fact]
        public void ElementShouldCreate()
        {
            Element test = new Element();
            Assert.NotNull(test);
        }
    }
}
