using Microsoft.Extensions.Logging;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Dao;
using MovieLibraryEntities.Models;
using System;
using System.Linq;

namespace ApplicationTemplate.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    
    private readonly IRepository _repository;
    private readonly ILogger<MovieContext> logger;

    public MainService(IRepository repository, ILogger<MovieContext> logger)
    {
        _repository = repository;
        this.logger = logger;
    }
    public void Invoke()
    {
        Console.WriteLine("1. search movie");
        Console.WriteLine("2. add movie");
        Console.WriteLine("3. list movies");
        //EXTRA CREDIT
        Console.WriteLine("4. update movie");
        Console.WriteLine("5. delete movie");
        Console.WriteLine("enter x to exit");
        Console.WriteLine();

        var choice = Console.ReadLine();
        if (choice != null && choice != "")
        {
            switch (choice)
            {
                // 1. search movie
                case "1":
                    Console.WriteLine();
                    Console.WriteLine("enter movies title: ");
                    var movieTitle = Console.ReadLine();
                    if (movieTitle != null && movieTitle != "")
                    {
                        var selectedTitle = _repository.Search(movieTitle);
                        if (selectedTitle.Any())
                        {
                            Console.WriteLine();
                            Console.WriteLine("Movies: \nId, Title (Release Date)");
                            foreach (var m in selectedTitle)
                            {
                                if (m.Id > 1682)
                                {
                                    Console.WriteLine($"{m.Id}, {m.Title} ({m.ReleaseDate.Year})");
                                }
                                else
                                {
                                    Console.WriteLine($"{m.Id}, {m.Title}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("movie not found!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("movie title cannot be blank");
                    }

                    break;
                // 2. add movie 
                case "2":
                    using (var db = new MovieContext(logger))
                    {
                        Console.WriteLine();
                        Console.WriteLine("enter movie title: ");
                        var movieTitle2 = Console.ReadLine();
                        if (movieTitle2 != null && movieTitle2 != "")
                        {
                            Console.WriteLine("enter release date (mm/dd/yyyy): ");
                            var movieReleaseDate = DateTime.Parse(Console.ReadLine());

                            var movie = new Movie
                            {
                                Title = movieTitle2,
                                ReleaseDate = movieReleaseDate
                            };

                            db.Movies.Add(movie);
                            db.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("movie title cannot be blank");
                        }
                    }
                    break;
                // 3. list movies
                case "3":
                    Console.WriteLine();
                    Console.WriteLine("listing all movies... ");
                    var allMovies = _repository.GetAll();
                    foreach (var m in allMovies)
                    {
                        if (m.Id > 1682)
                        {
                            Console.WriteLine($"{m.Id}, {m.Title} ({m.ReleaseDate.Year})");
                        }
                        else
                        {
                            Console.WriteLine($"{m.Id}, {m.Title}");
                        }
                    }
                    break;
                // 4. update movie - EXTRA CREDIT
                case "4":
                    using (var db = new MovieContext(logger))
                    {
                        Console.WriteLine();
                        Console.WriteLine("enter movie title to update: ");
                        var movieTitle4 = Console.ReadLine();
                        if(movieTitle4 != null && movieTitle4 != "")
                        {
                            var selectedTitle4 = db.Movies.FirstOrDefault(m => m.Title.ToLower().Contains(movieTitle4.ToLower()));

                            if (selectedTitle4 != null)
                            {
                                Console.WriteLine($"current selection: {selectedTitle4.Id}, {selectedTitle4.Title} - {selectedTitle4.ReleaseDate}");

                                Console.WriteLine();
                                Console.WriteLine("enter updated movie title: ");
                                var updatedTitle = Console.ReadLine();

                                if (updatedTitle != null && updatedTitle != "")
                                {
                                    Console.WriteLine("enter updated release date (mm/dd/yyyy): ");
                                    var updatedReleaseDate = DateTime.Parse(Console.ReadLine());

                                    selectedTitle4.Title = updatedTitle;
                                    selectedTitle4.ReleaseDate = updatedReleaseDate;

                                    db.SaveChanges();
                                    Console.WriteLine($"{movieTitle4} was updated to {updatedTitle}");
                                } else
                                {
                                    Console.WriteLine("movie title cannot be blank");
                                }                                
                            }
                            else
                            {
                                Console.WriteLine("error finding movie... no movie updated");
                            }
                        } else
                        {
                            Console.WriteLine("movie title cannot be blank");
                        }
                    }
                    break;
                // 5. delete movie - EXTRA CREDIT
                case "5":
                    using (var db = new MovieContext(logger))
                    {
                        Console.WriteLine();
                        Console.WriteLine("enter movie title to delete: ");
                        var movieTitle5 = Console.ReadLine();
                        if (movieTitle5 != null && movieTitle5 != "")
                        {
                            var selectedTitle5 = db.Movies.FirstOrDefault(m => m.Title.ToLower().Contains(movieTitle5.ToLower()));

                            if (selectedTitle5 != null)
                            {
                                Console.WriteLine($"current selection: {selectedTitle5.Id}, {selectedTitle5.Title} - {selectedTitle5.ReleaseDate}");

                                Console.WriteLine();
                                Console.WriteLine("is this the movie you want to delete? (y/n)");
                                var deleteConfirm = Console.ReadLine();

                                switch (deleteConfirm)
                                {
                                    //y for yes
                                    case "y":
                                        db.Movies.Remove(selectedTitle5);
                                        db.SaveChanges();
                                        Console.WriteLine($"{movieTitle5} was deleted");
                                        break;
                                    //n for no
                                    case "n":
                                        break;
                                    default:
                                        Console.WriteLine("please answer y for yes or n for no");
                                        break;
                                }
                            } else
                            {
                                Console.WriteLine("error finding movie... no movie deleted");
                            }
                        } else
                        {
                            Console.WriteLine("movie title cannot be blank");
                        }
                    }
                    break;
                case "x":
                    break;
                default:
                    Console.WriteLine("please try again ⟲");
                    break;
            }
        }
        else
        {
            Console.WriteLine("please enter a valid option");
        }
    }
}