using ApplicationTemplate.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApplicationTemplate
{
    public class MovieService : IMovieService
    {
        private readonly ILogger<IMovieService> log;

        public MovieService(ILogger<IMovieService> logger)
        {
            log = logger;
        }
        
        public void Read()
        {
        string movieDataFile = "C:\\Users\\julzz\\source\\repos\\ApplicationTemplate\\Files\\movies.csv";

            if (File.Exists(movieDataFile))
            {
                StreamReader sr = new StreamReader(movieDataFile);

                Console.WriteLine("how many entries would you like to see? ('A' will show ALL records) ");
                var choice1 = Console.ReadLine().ToUpper();
                sr.ReadLine();
                if (choice1 != "A")
                {
                    int number = 0;
                    while (number < int.Parse(choice1))
                    {
                        string line1 = sr.ReadLine();
                        Console.WriteLine(line1);
                        number++;
                    }
                }
                else
                {
                    while (!sr.EndOfStream)
                    {
                        string line2 = sr.ReadLine();
                        Console.WriteLine(line2);
                    }
                }
                sr.Close();

            } else
            {
                Console.WriteLine("the file doesn't exist");
            }
        }

        public void Write()
        {
            string movieDataFile = "C:\\Users\\julzz\\source\\repos\\ApplicationTemplate\\Files\\movies.csv";
            try
            {
                List<MovieStructure> movieList = new List<MovieStructure>();

                using var reader = new StreamReader(movieDataFile);
                MovieStructure movie = new MovieStructure();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line3 = reader.ReadLine();

                    string[] movieInfo = line3.Split(',');
                    movie.id = int.Parse(movieInfo[0]);
                    movie.title = movieInfo[1];
                    movieList.Add(movie);
                }

                reader.Close();


                StreamWriter write = new StreamWriter(movieDataFile, true);
                string response = "";
                do
                {
                    movie.id = movieList.Max(m => m.id) + 1;

                    Console.WriteLine(" enter movie title: ");
                    string movieTitle = Console.ReadLine();
                    if (movie.title.Contains(movieTitle))
                    {
                        Console.WriteLine(" movie already exists in file ");
                        Console.WriteLine(" please enter a new movie title: ");
                        movieTitle = Console.ReadLine();
                        if (movieTitle.Contains(','))
                        {
                            movieTitle = "\"title\"";
                        }
                    }


                    var choice2 = "";
                    var movieGenre = new List<string>();
                    
                    do
                    {
                        Console.WriteLine(" enter movie genre: ");
                        movieGenre.Add(Console.ReadLine());
                        Console.WriteLine(" add another genre? (Y/N) ");
                        choice2 = Console.ReadLine().ToUpper();

                    } while (choice2 == "Y");

                    string movieGenres = string.Join("|", movieGenre);

                    write.WriteLine("{0},{1},{2}", movie.id, movieTitle, movieGenres);
                    Console.WriteLine(" add another movie? (Y/N) ");
                    response = Console.ReadLine().ToUpper();

                } while (response == "Y");

                write.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("this file is lost");
            }
        }
    }
}