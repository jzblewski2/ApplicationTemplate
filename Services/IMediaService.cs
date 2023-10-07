using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTemplate.Services
{
    public interface IMediaService
    {
        void ReadMovies();
        void ReadShows();
        void ReadVideos();
    }
}
