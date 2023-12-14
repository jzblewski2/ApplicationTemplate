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
        Console.WriteLine("6. add user");
        Console.WriteLine("7. rate movie");
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
                            Console.WriteLine($"{movieTitle2} was added");
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
                        if (movieTitle4 != null && movieTitle4 != "")
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
                                }
                                else
                                {
                                    Console.WriteLine("movie title cannot be blank");
                                }
                            }
                            else
                            {
                                Console.WriteLine("error finding movie... no movie updated");
                            }
                        }
                        else
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
                                    case "Y":
                                        db.Movies.Remove(selectedTitle5);
                                        db.SaveChanges();
                                        Console.WriteLine($"{movieTitle5} was deleted");
                                        break;
                                    //n for no
                                    case "n":
                                    case "N":
                                        break;
                                    default:
                                        Console.WriteLine("please answer y for yes or n for no");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("error finding movie... no movie deleted");
                            }
                        }
                        else
                        {
                            Console.WriteLine("movie title cannot be blank");
                        }
                    }
                    break;

                //6. add user
                case "6":
                    using (var db = new MovieContext(logger))
                    {
                        Console.WriteLine();
                        Console.WriteLine("enter user's age: ");
                        var userAge = long.Parse(Console.ReadLine());
                        if (userAge >= 0)
                        {
                            Console.WriteLine("enter user's gender (M/F): ");
                            var userGender = Console.ReadLine().ToUpper();
                            if (userGender == "M" || userGender == "F")
                            {
                                Console.WriteLine("enter user's zip code: ");
                                var userZipCode = Console.ReadLine();
                                if (userZipCode != null && userZipCode != "")
                                {
                                    var occupationOptions = _repository.GetAllOccupations();

                                    Console.WriteLine();
                                    Console.WriteLine("Occupation Options: ");
                                    foreach (var occ in occupationOptions)
                                    {
                                        Console.WriteLine($"{occ.Id}. {occ.Name}");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("enter user's occupation (corresponding id): ");
                                    long? userOccupation = int.Parse(Console.ReadLine());

                                    var occupation = occupationOptions.FirstOrDefault(x => x.Id == userOccupation);

                                    if (userOccupation != null && userOccupation != 0)
                                    {
                                        var user = new User
                                        {
                                            Age = userAge,
                                            Gender = userGender,
                                            ZipCode = userZipCode,
                                            OccupationId = occupation.Id
                                        };

                                        db.Users.Add(user);
                                        db.SaveChanges();


                                        Console.WriteLine($"User added: \nId: {user.Id}\nAge: {user.Age}\nGender: {user.Gender}\nZip Code: {user.ZipCode}\nOccupation Id: {user.OccupationId}");
                                        Console.WriteLine("*** please remember user id to rate a movie ***");
                                    }
                                    else
                                    {
                                        Console.WriteLine("please enter valid occupation");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("please enter valid zip code");
                                }
                            }
                            else
                            {
                                Console.WriteLine("please enter M for male or F for female");
                            }
                        }
                        else
                        {
                            Console.WriteLine("age cannot be under 0");
                        }
                    }
                    break;
                case "7":
                    using (var db = new MovieContext(logger))
                    {
                        Console.WriteLine();
                        Console.WriteLine("enter user id: ");
                        var userId = int.Parse(Console.ReadLine());
                        var selectedUser = db.Users.FirstOrDefault(u => u.Id == userId);
                        if (selectedUser != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"current selection: Id:{selectedUser.Id}, Age:{selectedUser.Age}, Gender:{selectedUser.Gender}, Zip:{selectedUser.ZipCode}, OccupationId: {selectedUser.OccupationId}");
                            Console.WriteLine("is this correct? (y/n)");
                            var userConfirm = Console.ReadLine();
                            if (userConfirm == "y" || userConfirm == "Y")
                            {
                                Console.WriteLine();
                                Console.WriteLine("enter movie id to rate: ");
                                var movieId = int.Parse(Console.ReadLine());
                                var selectedMovie = db.Movies.FirstOrDefault(m => m.Id == movieId);
                                if (selectedMovie != null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"current selection: {selectedMovie.Id}, {selectedMovie.Title} - {selectedMovie.ReleaseDate}");
                                    Console.WriteLine("is this correct? (y/n)");
                                    var userConfirm2 = Console.ReadLine();
                                    if (userConfirm2 == "y" || userConfirm2 == "Y")
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("enter movie rating (1 - 5): ");
                                        var movieRating = int.Parse(Console.ReadLine());
                                        if (movieRating >= 1 && movieRating <= 5)
                                        {
                                            var userMovieRating = new UserMovie
                                            {
                                                Rating = movieRating,
                                                RatedAt = DateTime.Now,
                                                User = selectedUser,
                                                Movie = selectedMovie
                                            };

                                            db.UserMovies.Add(userMovieRating);
                                            db.SaveChanges();

                                            Console.WriteLine();
                                            Console.WriteLine("Movie rating added... ");
                                            Console.WriteLine($"Rating Id: {userMovieRating.Id}\nRating: {userMovieRating.Rating}\nRated At: {userMovieRating.RatedAt}\nUser Id: {userMovieRating.User.Id}\nMovie Id: {userMovieRating.Movie.Id}\nTitle: {userMovieRating.Movie.Title}");
                                        } else
                                        {
                                            Console.WriteLine("rating must be between 1 and 5");
                                        }
                                    } else
                                    {
                                        break;
                                    }
                                } else
                                {
                                    Console.WriteLine("error finding movie... no movie to rate");
                                }
                            } else
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("error finding user... please try again");
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