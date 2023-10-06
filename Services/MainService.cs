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
    public MainService()
    {
       
    }
    public void Invoke()
    {
        string choice;
        do
        {
            Console.WriteLine("1. Display Movies");
            Console.WriteLine("2. Display Shows");
            Console.WriteLine("3. Display Videos");
            Console.WriteLine("press 0 to exit");
            choice = Console.ReadLine();
            Media media = null;

            switch (choice)
            {
                case "1":
                    media = new Movie { Id = 1, Title = "Toy Story", Genres = "Animation, Adventure" };
                    break;
                case "2":
                    media = new Show { Id = 1, Title = "Supernatural", Season = 2, Episode = 12, Writers = "Kripke" };
                    break;
                case "3":
                    media = new Video { Id = 1, Title = "Lethal Weapon 3", Format = "VHS, DVD, BluRay", Length = 100, Regions = "0,2" };
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
