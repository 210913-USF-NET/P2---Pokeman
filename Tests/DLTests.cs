using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DL;
using Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Tests
{
    public class DLTests
    {
        private readonly DbContextOptions<PokeMatchDb> options;

        public DLTests()
        {
            options = new DbContextOptionsBuilder<PokeMatchDb>().UseSqlite("Filename=Test.db").Options;

            Seed();
        }

        private void Seed()
        {
            using (var context = new PokeMatchDb(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //context.Users.AddRange(
                //    new User()
                //    {

                //        Id = 12,
                //        Username = "Pokepal",
                //        Password = "123",
                //        Email = "fake@yahoo.com",
                //        Gender = "Female",
                //        Interest = "Female",
                //        ElementId = 4



                //    },
                //new User()
                //{
                //    Id = 13,
                //    Username = "MonCollector",
                //    Password = "123",
                //    Email = "lovebird@aol.com",
                //    Gender = "Male",
                //    Interest = "Male",
                //    ElementId = 5

                //}
                //);

                context.Elements.AddRange(
                    new List<Element> 
                    {

                       new Element()
                    {
                        Id = 4,
                        Name = "Bug"

                    },
                    new Element()
                    {
                        Id = 5,
                        Name = "Electric"
                    }

                    }
                 

                        );
                    //context.Pokemons.Add(
                    //    new Pokemon()
                    //    {
                    //        Id = 1,
                    //        Name = "bulbasaur"


                    //    }
                    //new Pokemon()
                    //{
                    //    Id = 2,
                    //    Name = "ivysaur"
                    //}
                    //);

                context.SaveChanges();
            }
        }


        [Fact]
        public void AddingUserShouldAddUser()
        {
            using (var context = new PokeMatchDb(options))
            {
                IRepo repo = new DBRepo(context);
                User userToAdd = new User()
                {
                    Id = 3,
                    Username = "AshK",
                    Password = "123",
                    Email = "test@gmail.com",
                    Gender = "Male",
                    Interest = "Other",
                    ElementId = 4
                };

                repo.AddUserAsync(userToAdd);
            }

            using (var context = new PokeMatchDb(options))
            {
                User user = context.Users.FirstOrDefault(u => u.Id == 3);

                Assert.NotNull(user);
                Assert.Equal("AshK", user.Username);
                Assert.Equal("123", user.Password);
                Assert.Equal("test@gmail.com", user.Email);
                Assert.Equal("Male", user.Gender);
                Assert.Equal("Other", user.Interest);
                Assert.Equal(4, user.ElementId);


            }
        }

        [Fact]
        public async void AddingAnElementShouldAddAnElement()
        {
            using (var context = new PokeMatchDb(options))
            {
                IRepo repo = new DBRepo(context);
                Element eleToAdd = new Element()
                {
                    Id = 6,
                    Name = "Fairy"
                };

                await repo.AddElementAsync(eleToAdd);
            }

            using (var context = new PokeMatchDb(options))
            {
                Element ele = context.Elements.FirstOrDefault(e => e.Id == 6);

                Assert.NotNull(ele);
                Assert.Equal(6, ele.Id);
                Assert.Equal("Fairy", ele.Name);
            }
        }

        [Fact]
        public async void GetAllElementsShouldGetAllElements()
        {
            using (var context = new PokeMatchDb(options))
            {

                IRepo repo = new DBRepo(context);


                var elements = await repo.GetElementListAsync();

                Assert.NotNull(elements);
                Assert.Equal(2, elements.Count);
            }
        }

        [Fact]
        public async void UpdatingElementShouldUpdate()
        {
            using (var context = new PokeMatchDb(options))
            {

                IRepo repo = new DBRepo(context);
                Element elementToUpdate = await repo.GetElementByIdAsync(4);

                elementToUpdate.Name = "Dark";


                await repo.UpdateElementAsync(elementToUpdate);
            }

            using (var context = new PokeMatchDb(options))
            {

                Element element = context.Elements.FirstOrDefault(e => e.Id == 4);

                Assert.NotNull(element);
                Assert.Equal("Dark", element.Name);
            }
        }

        //[Fact]
        //public void RemovingElementShouldRemove()
        //{
        //    using (var context = new PokeMatchDb(options))
        //    {
        //        //Arrange with my repo and the item i'm going to add
        //        IRepo repo = new DBRepo(context);
        //        Element eleToRemove = repo.GetElementByIdAsync(1);

        //        //Act
        //        repo.DeleteElementAsync(eleToRemove);
        //    }

        //    using (var context = new PokeMatchDb(options))
        //    {
        //        //Assert
        //        Element element = context.Elements.FirstOrDefault(r => r.Id == 1);

        //        Assert.Null(element);
        //    }
        //}

        //[Fact]
        //public void AddingAnPokemonShouldAddAnPokemon()
        //{
        //    using (var context = new PokeMatchDb(options))
        //    {
        //        IRepo repo = new DBRepo(context);
        //        Pokemon pokeToAdd = new Pokemon()
        //        {
        //            Id = 1,
        //            Name = "bulbasaur"
        //        };

        //        repo.AddPokemonAsync(pokeToAdd);
        //    }

        //    using (var context = new PokeMatchDb(options))
        //    {
        //        Pokemon poke = context.Pokemons.FirstOrDefault(p => p.Id == 6);

        //        Assert.NotNull(poke);
        //        Assert.Equal(1, poke.Id);
        //        Assert.Equal("bulbasaur", poke.Name);
        //    }
        //}


        //[Fact]
        //public void GetAllUsersShouldGetAllUsers()
        //{
        //    List<User> allUsers = new List<User>();
        //    using (var context = new PokeMatchDb(options))
        //    {
        //        //Arrange
        //        IRepo repo = new DBRepo(context);

        //        //Act
        //        var users = repo.GetUserListAsync();

        //        //Assert

        //        Assert.Equal(2, allUsers.Count);
        //    }
        //}

    }
}
