using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRating
    {
        public int ID { get; set; }
        public string Movie { get; set; }
        public decimal Rating { get; set; }
    }
}
