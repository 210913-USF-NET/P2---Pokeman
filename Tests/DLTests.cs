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
                    new User()
                    {

                        Id = 12,
                        Username = "Pokepal",
                        Password = "123",
                        Email = "fake@yahoo.com",
                        Gender = "Female",
                        Interest = "Female",
                        ElementId = 4



                    },
                new User()
                {
                    Id = 13,
                    Username = "MonCollector",
                    Password = "123",
                    Email = "lovebird@aol.com",
                    Gender = "Male",
                    Interest = "Male",
                    ElementId = 5

                }
                );

                context.Elements.AddRange(
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
                    
                    );

                context.SaveChanges();
            }
        }


        //[Fact]
        //public async Task AddingUserShouldAddUser()
        //{
        //    await using (var context =  new PokeMatchDb(options))
        //    {
        //        IRepo repo = new DBRepo(context);
        //       User userToAdd = new User()
        //        {
        //            Id = 3,
        //            Username = "AshK",
        //            Password = "123",
        //            Email = "testc@gmail.com",
        //            Gender = "Male",
        //            Interest = "Other",
        //            ElementId = 2
        //        };

        //        repo.AddUserAsync(userToAdd);
        //    }

        //    await using(var context = new PokeMatchDb(options))
        //    {
        //        User user = context.Users.FirstOrDefault(u => u.Id == 3);

        //        Assert.NotNull(user);
        //        Assert.Equal("AshK", user.Username);
        //        Assert.Equal("123", user.Password);
        //        Assert.Equal("test@gmail.com", user.Email);
        //        Assert.Equal("Male", user.Gender);
        //        Assert.Equal("Interest", user.Interest);
        //        Assert.Equal(2, user.ElementId);
               
                
        //    }
        //}

        [Fact]
        public void AddingAnElementShouldAddAnElement()
        {
            using (var context = new PokeMatchDb(options))
            {
                IRepo repo = new DBRepo(context);
                Element eleToAdd = new Element()
                {
                    Id = 6,
                    Name = "Fairy"
                };

                repo.AddElementAsync(eleToAdd);
            }

            using (var context = new PokeMatchDb(options))
            {
                Element ele = context.Elements.FirstOrDefault(e => e.Id == 6);

                Assert.NotNull(ele);
                Assert.Equal(6, ele.Id);
                Assert.Equal("Fairy", ele.Name);
            }
        }


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
