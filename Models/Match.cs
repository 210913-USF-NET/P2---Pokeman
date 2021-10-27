using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Match
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string ImgUrl { get; set; }

        public int UserId { get; set; }

        public int UserId2 { get; set; }

        public List<Message> Messages { get; set; }

    }
}
