﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DL;

namespace BL
{
    public class PokeBL : IBL
    {
        private IRepo _repo;

        public PokeBL(IRepo irepo)
        {
            _repo = irepo;
        }

        Task<User> createUser(User newUser)
        {
            throw new NotImplementedException();
        }

        Task<List<User>> ListOfUsers()
        {
            throw new NotImplementedException();
        }

        Task<User> SearchUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
