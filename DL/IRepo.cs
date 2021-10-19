using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface IRepo
    {

    //*****************************Adding/Creating********************************

        Task<User> AddUserAsync(User user);

        Task<Element> AddElementAsync(Element ele);

    //*****************************Get One********************************   


        Task<Element> GetOneElementByIdAsync(int id);

    //*****************************Get All********************************

        Task<List<User>> GetAllUsersAsync();

        Task<List<Element>> GetAllElementsAsync();
        
    }
}

