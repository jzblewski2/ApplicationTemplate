using ApplicationTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTemplate.Data
{
    public class Context
    {
        public List<Movie> Movies { get; set; }
        public List<Show> Shows { get; set; }
        public List<Video> Videos { get; set; }

        //public void Add(Movie movie, Show show, Video video)
        //{
        //    Movies.Add(movie);
        //    Shows.Add(show);
        //    Videos.Add(video);
        //}

        public Context() 
        {
            Movies = new List<Movie>();
            Shows = new List<Show>();
            Videos = new List<Video>();
        }
    }
}
