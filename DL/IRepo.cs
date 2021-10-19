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

        //------------------------------------Methods For Getting List--------------------------------------
        
        public Task<List<Element>> GetAllElementsAsync();

        //------------------------------------Methods for Adding To DB--------------------------------------

        Task<User> AddUserAsync(User user);

        Task<Element> AddElementAsync(Element ele);


        //------------------------------------Methods for Updating DB--------------------------------------

        Task<Element> GetOneElementByIdAsync(int id);

    }
}

