using ApplicationTemplate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTemplate.Services
{
    public class MediaService : IMediaService
    {
        public void ReadMovies()
        {
            string movieFile = "C:\\Users\\julzz\\source\\repos\\ApplicationTemplate\\Files\\movies.csv";

            if (System.IO.File.Exists(movieFile))
            {
                StreamReader sr = new StreamReader(movieFile);

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

            }
            else
            {
                Console.WriteLine("the file doesn't exist");
            }
        }


        public void ReadShows()
        {
            string showFile = "C:\\Users\\julzz\\source\\repos\\ApplicationTemplate\\Files\\shows.csv";

            if (System.IO.File.Exists(showFile))
            {
                StreamReader sr = new StreamReader(showFile);

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

            }
            else
            {
                Console.WriteLine("the file doesn't exist");
            }
        }

        public void ReadVideos()
        {
            string showFile = "C:\\Users\\julzz\\source\\repos\\ApplicationTemplate\\Files\\videos.csv";

            if (System.IO.File.Exists(showFile))
            {
                StreamReader sr = new StreamReader(showFile);

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

            }
            else
            {
                Console.WriteLine("the file doesn't exist");
            }
        }
    }
}
