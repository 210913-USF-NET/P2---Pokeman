using System;
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

        /*Task<User> createUser(User newUser);

        Task<List<User>> ListOfUsers();
     

        Task<User> SearchUser(User user);*/

        //Element

        public Task<Element> AddElementAsync(Element ele);

        public Task<Element> GetOneElementByIdAsync(int id);

        public Task<List<Element>> GetAllElementsAsync();
        Task<ElementGroup> CreateElementGroupAsync(ElementGroup newElementGroup);
    }
}
