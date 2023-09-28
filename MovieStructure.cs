using System;
using System.Collections.Generic;

namespace ApplicationTemplate
{
    internal class MovieStructure
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<string> genre { get; set; }

        public MovieStructure() 
        {
            genre = new List<string>();
        }
    }
}
