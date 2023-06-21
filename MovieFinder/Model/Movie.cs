using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder.Model
{
    public class Root
    {
        public List<Movie> Search { get; set; }
    }
    public class Movie
    {
        public string Title{ get; set; }
        public string Year { get; set; }  

        public string imdbID { get; set; }

        public string Type { get; set; }

        public string Poster { get; set; }

    }
}
