using ApplicationTemplate.Data;
using ApplicationTemplate.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ApplicationTemplate.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{

    private readonly IContext _context;

    public MainService(IContext context)
    {
        _context = context;
    }
    public void Invoke()
    {
        Console.WriteLine("1. get movie by id");
        Console.WriteLine("2. get movie by title");
        Console.WriteLine("3. find movie(s) with title");

        var choice = Console.ReadLine();

        // provide an option to the user to 
        
        switch (choice)
        {
        // 1. select by id
            case "1":
                Console.WriteLine();
                Console.WriteLine("movie id: ");
                int selectId = int.Parse(Console.ReadLine());
                var getById = _context.GetById(selectId);
                Console.WriteLine($"Your movie is {getById.Title}");
                break;
        // 2. select by title 
            case "2":
                Console.WriteLine();
                Console.WriteLine("movie title: ");
                var selectTitle = Console.ReadLine();
                var getByTitle = _context.GetByTitle(selectTitle);
                Console.WriteLine($"Your movie is {getByTitle.Title}");
                break;
        // 3. find movie by title
            case "3":
                Console.WriteLine();
                Console.WriteLine("movie title: ");
                var selectTitles = Console.ReadLine();
                var listMovies = _context.FindMovie(selectTitles);
                if (listMovies.Any())
                {
                    Console.WriteLine();
                    Console.WriteLine("Movies: \n(Id, Title)");
                    foreach (var movie in listMovies)
                    {
                        Console.WriteLine($"{movie.Id}, {movie.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("movie not found!");
                }
                break;
            default:
                Console.WriteLine("please try again ⟲");
                break;
        }
    }
}