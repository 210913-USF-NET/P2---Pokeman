using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public User() { }
        public User(User person)
        {
            this.Id = person.Id;
            this.Username = person.Username;
            this.Password = person.Password;
            this.Email = person.Email;
            this.ElementId = person.ElementId;
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int ElementId { get; set; }

        List<Element> Elements { get; set; }
    }
}
