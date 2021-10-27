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

                context.Users.AddRange(
                    new List<User>
                    {
                    new User()
                    {

                        Id = 1,
                        Username = "Pokepal",
                        Password = "123",
                        Email = "fake@yahoo.com",
                        Gender = "Female",
                        Interest = "Female",
                         profilepic = "test",
                        ElementId = 4



                    },
                new User()
                {
                    Id = 2,
                    Username = "MonCollector",
                    Password = "123",
                    Email = "lovebird@aol.com",
                    Gender = "Male",
                    Interest = "Male",
                    profilepic = "test",
                    ElementId = 5

                }
                }
                );

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
                context.Matches.Add(
                      new Models.Match()
                      { 
                        Id = 1,
                        Name = "Test",
                        ImgUrl = "test",
                        UserId = 1,
                        UserId2 = 2
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
                    profilepic = "test",
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
                Assert.Equal("test", user.profilepic);
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



        [Fact]
        public async void AddingAPokemonShouldAddAPokemon()
        {
            using (var context = new PokeMatchDb(options))
            {
                IRepo repo = new DBRepo(context);
                Pokemon pokeToAdd = new Pokemon()
                {
                    Id = 4,
                    Name = "mew",
                    Hp = 100,
                    ImgUrl = "test",
                    UserId = 1
                };

                await repo.AddPokemonAsync(pokeToAdd);
            }

            using (var context = new PokeMatchDb(options))
            {
                Pokemon poke = context.Pokemons.FirstOrDefault(p => p.Id == 4);

                Assert.NotNull(poke);
                Assert.Equal(4, poke.Id);
                Assert.Equal("mew", poke.Name);
                Assert.Equal(100, poke.Hp);
                Assert.Equal("test", poke.ImgUrl);
                Assert.Equal(1, poke.UserId);
            }
        }


        [Fact]
        public async void AddingAMatchShouldAddAMatch()
        {
            using (var context = new PokeMatchDb(options))
            {
                IRepo repo = new DBRepo(context);
                Models.Match matchToAdd = new Models.Match()
                {
                    Id = 2,
                    Name = "Gravy",
                    ImgUrl = "test",
                    UserId = 1,
                    UserId2 = 2
                    
                };

                await repo.AddMatchAsync(matchToAdd);
            }

            using (var context = new PokeMatchDb(options))
            {
                Models.Match mat = context.Matches.FirstOrDefault(m => m.Id == 2);

                Assert.NotNull(mat);
                Assert.Equal(2, mat.Id);
                Assert.Equal("Gravy", mat.Name);
                Assert.Equal("test", mat.ImgUrl);
                Assert.Equal(1, mat.UserId);
                Assert.Equal(2, mat.UserId2);
            }
        }

        [Fact]
        public async void GetAllUsersShouldGetAllUsers()
        {
            
            using (var context = new PokeMatchDb(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var users = await repo.GetUserListAsync();

                //Assert
                Assert.NotNull(users);
                Assert.Equal(2, users.Count);
            }
        }

        [Fact]
        public async void AddingAMessageShouldAddAMessage()
        {
            using (var context = new PokeMatchDb(options))
            {
                IRepo repo = new DBRepo(context);
                Message mssgToAdd = new Message()
                {
                    Id = 1,
                    ToUser = "Joy",
                    FromUser = "Jenny",
                    Send = "Hello!",
                    Recieve = "Hiya",
                    MatchId = 1

                };

                await repo.AddMessageAsync(mssgToAdd);
            }

            using (var context = new PokeMatchDb(options))
            {
                Message mssg = context.Messages.FirstOrDefault(m => m.Id == 1);

                Assert.NotNull(mssg);
                Assert.Equal(1, mssg.Id);
                Assert.Equal("Joy", mssg.ToUser);
                Assert.Equal("Jenny", mssg.FromUser);
                Assert.Equal("Hello!", mssg.Send);
                Assert.Equal("Hiya", mssg.Recieve);
                Assert.Equal(1, mssg.MatchId);
            }
        }

    }
}

