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
        

        //Element
        public Task<Element> AddElementAsync(Element ele);

        public Task<Element> GetOneElementByIdAsync(int id);

        public Task<List<Element>> GetAllElementsAsync();
        
    }
}

