using ApplicationTemplate.Models;
using System.Collections.Generic;

namespace ApplicationTemplate.Data
{
    public interface IContext
    {
        Movie GetById(int id);
        Movie GetByTitle(string title);

        List<Movie> FindMovie(string title);
    }
}