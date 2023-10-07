using ApplicationTemplate.Data;
using ApplicationTemplate.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationTemplate.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IMediaService _mediaService;
    public MainService(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }
    public void Invoke()
    {
        string choice;
        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Display Movies");
            Console.WriteLine("2. Display Shows");
            Console.WriteLine("3. Display Videos");
            Console.WriteLine("press 0 to exit");
            choice = Console.ReadLine();
            Media media = null;

            switch (choice)
            {
                case "1":
                    _mediaService.ReadMovies();
                    break;
                case "2":
                    _mediaService.ReadShows();
                    break;
                case "3":
                    _mediaService.ReadVideos();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("please try again ⟲");
                    break;
            } media?.Display();
        }while (choice != "0");
        
    }
}
