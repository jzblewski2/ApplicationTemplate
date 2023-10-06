using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTemplate.Models
{
        public class Movie : Media
        {
            public string Genres { get; set; }

            public override string Display()
            {
                return $"ID: {Id}, Title: {Title}, Genres: {Genres}";
            }
        }
}