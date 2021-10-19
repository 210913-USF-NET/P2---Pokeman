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
        public Task<User> AddUserAsync(User user);

        public Task<ElementGroup> CreateElementGroupAsync(ElementGroup newElementGroup);
        

        //Element
        public Task<Element> AddElementAsync(Element ele);

        public Task<Element> GetOneElementByIdAsync(int id);

        public Task<List<Element>> GetAllElementsAsync();
        
    }
}

