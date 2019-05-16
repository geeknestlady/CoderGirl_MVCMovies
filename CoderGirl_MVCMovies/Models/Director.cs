﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class Director
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string LastFirst
        {
            get { return $"{LastName}, {FirstName}"; }
        }
        public int Id { get; set; }
    }
}
