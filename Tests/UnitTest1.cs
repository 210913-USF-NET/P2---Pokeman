using System;
using Xunit;
using Models;
using DL;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class ModelTests
    {
        private readonly DbContextOptions<PokeMatchDb> options;

        public ModelTests()
        {
            options = new DbContextOptionsBuilder<PokeMatchDb>()
                .UseSqlite("Filename=Test.db").Options;
        }

        [Fact]
        public void ElementShouldCreate()
        {
            Element test = new Element();
            Assert.NotNull(test);
        }
    }
}
