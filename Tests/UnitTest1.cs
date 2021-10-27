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

         [Fact]
        public void ElementShouldSetValidData()
        {
            //Arrange
            Element test = new Element();
            string testName = "test element";

            //Act
            test.Name = testName;

            //Assert
            Assert.Equal(testName, test.Name);
        }

        [Fact]
        public void UserShouldCreate()
        {
            User test = new User();

            Assert.NotNull(test);
        }

        [Fact]
        public void UserShouldSetValidData()
        {
            //Arrange
            User test = new User();
            string testName = "test element";

            //Act
            test.Username = testName;

            //Assert
            Assert.Equal(testName, test.Username);
        }

        [Fact]
        public void MoveShouldCreate()
        {
            User test = new User();

            Assert.NotNull(test);
        }

        [Fact]
        public void MoveShouldSetValidData()
        {
            //Arrange
            Move test = new Move();
            int testId = 1;

            //Act
            test.Id = testId;

            //Assert
            Assert.Equal(testId, test.Id);
        }

        [Fact]
        public void MatchShouldCreate()
        {
           Match test = new Match();

            Assert.NotNull(test);
        }

        [Fact]
        public void MatchShouldSetValidData()
        {
            //Arrange
            Match test = new Match();
            int testId = 1;

            //Act
            test.Id = testId;

            //Assert
            Assert.Equal(testId, test.Id);
        }

        [Fact]
        public void MessageShouldCreate()
        {
            Message test = new Message();

            Assert.NotNull(test);
        }

        [Fact]
        public void MessageShouldSetValidData()
        {
            //Arrange
            Message test = new Message();
            int testId = 1;

            //Act
            test.Id = testId;

            //Assert
            Assert.Equal(testId, test.Id);
        }

        [Fact]
        public void PokemonShouldCreate()
        {
            Pokemon test = new Pokemon();

            Assert.NotNull(test);
        }

        [Fact]
        public void PokemonShouldSetValidData()
        {
            //Arrange
            Pokemon test = new Pokemon();
            int testId = 1;

            //Act
            test.Id = testId;

            //Assert
            Assert.Equal(testId, test.Id);
        }
    }
}
