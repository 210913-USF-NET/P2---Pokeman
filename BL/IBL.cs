﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DL;

namespace BL
{
    public interface IBL
    {

        Task<User> AddUserAsync(User user);
  
        Task<Element> AddElementAsync(Element ele);

        Task<Element> GetOneElementByIdAsync(int id);

        Task<List<Element>> GetAllElementsAsync();
    }
}
