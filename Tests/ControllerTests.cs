using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DL;
using WebAPI.Controllers;
using Models;
using Microsoft.EntityFrameworkCore;
using BL;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Configuration;

//namespace Tests
//{
//    public class Tests
//    {
//        //private readonly DbContextOptions<PokeMatchDb> options;
//        private readonly IBL configuration;

//        [Fact]
        
//        public async void Get_GetListOfElements()
//        {
//            var configure = GetConfig();

//            var sut = new ElementController(configuration);

//            var result = await sut.Get();

//            Assert.Equal(2, result.Count());

//        }

//        private IConfiguration GetConfig()
//        {
//            var builder = new ConfigurationBuilder()
//              .SetBasePath(Directory.GetCurrentDirectory())
//              .AddJsonFile("appsettings.json", true, true)
//              .AddEnvironmentVariables();

//            return builder.Build();
//        }
//    }
//}
