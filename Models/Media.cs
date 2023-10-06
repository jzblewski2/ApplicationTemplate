using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTemplate.Models
{
    public class File
    {
        public void Method()
        {
            Media mediaMovie = new Movie();
            ((Movie)mediaMovie).Display();

            Media mediaShow = new Show();
            ((Show)mediaShow).Display();

            Media mediaVideo = new Video();
            ((Video)mediaVideo).Display();
        }
    }
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Media() { }

        public abstract string Display();

    }
}

