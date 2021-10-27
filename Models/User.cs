using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Interest { get; set; }

        public int ElementId { get; set; }

        public string profilepic { get; set; }

        public List<Match> Matches { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
