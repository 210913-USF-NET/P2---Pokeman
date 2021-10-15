﻿using System;
using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int ElementId { get; set; }

        public List<Element> Elements { get; set; }
    }
}