using System;

namespace ApplicationTemplate.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IFileService _fileService;
    private readonly IMovieService _movieService;
    public MainService(IFileService fileService, IMovieService movieService)
    {
        _fileService = fileService;
        _movieService = movieService;
    }

    public void Invoke()
    {
        string choice;
        do
        {
            Console.WriteLine("1) Add Movie");
            Console.WriteLine("2) Display All Movies");
            Console.WriteLine("X) Quit");
            choice = Console.ReadLine();

            // Logic would need to exist to validate inputs and data prior to writing to the file
            // You would need to decide where this logic would reside.
            // Is it part of the FileService or some other service?
            if (choice == "1")
            {
                _movieService.Write();
            }
            else if (choice == "2")
            {
                _movieService.Read();
            }
        }
        while (choice != "X");
    }
}
