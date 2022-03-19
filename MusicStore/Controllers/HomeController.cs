using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using System.Diagnostics;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private List<Album> albums;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Search(string searchBy, string searchText)
        {
            MakeAlbums();
            if (searchText != null)
            {
                List<Album> results;
                searchText.ToLower();

                if (searchBy == "Artist")
                {
                    results = albums.Where(x => x.Artist.ToLower().Contains(searchText)).ToList();
                }
                else if (searchBy == "Title")
                {
                    results = albums.Where(x => x.Title.ToLower().Contains(searchText)).ToList();
                }
                else if (searchBy == "Year")
                {
                    results = albums.Where(x => x.Year == Int32.Parse(searchText)).ToList();
                }
                else
                {
                    results = albums.Where(x => x.Artist.ToLower().Contains(searchText)).ToList();
                    /*
                 *  Was notr sure how to do this last part in C# -Dakota
                 */
                }
                return View(results);
            }
            else
            {
                return View(albums);
            }
            
        }

        /*
         * helper method that makes some sample albums
         */
        private void MakeAlbums()
        {
            albums = new List<Album>
            {
                new Album {
                    Id = 1,
                    Title = "Look What the Cat Dragged In",
                    Artist = "Poison",
                    Year = 1986
                },

               new Album {
                    Id = 2,
                    Title = "Shout at the Devil",
                    Artist = "Motley Crue",
                    Year = 1983
                },

                new Album {
                    Id = 3,
                    Title = "Appetite for Destruction",
                    Artist = "Guns N Roses",
                    Year = 1987
                },

                new Album {
                    Id = 4,
                    Title = "Detonator",
                    Artist = "Ratt",
                    Year = 1990
                },

                new Album {
                    Id = 5,
                    Title = "Dirty Rotten Filthy Stinking Rich",
                    Artist = "Warrant",
                    Year = 1988
                },

                new Album {
                    Id = 6,
                    Title = "New Jersey",
                    Artist = "Bon Jovi",
                    Year = 1988
                },

                new Album {
                    Id = 7,
                    Title = "Master of Puppets",
                    Artist = "Metallica",
                    Year = 1986
                },

                new Album {
                    Id = 8,
                    Title = "Screaming for Venegance",
                    Artist = "Judas Priest",
                    Year = 1982
                },

                new Album {
                    Id = 9,
                    Title = "Blackout",
                    Artist = "Die Scorpions",
                    Year = 1982
                },

                new Album {
                    Id = 10,
                    Title = "Hysteria",
                    Artist = "Def Leppard",
                    Year = 1987
                },

                new Album {
                    Id = 11,
                    Title = "Whitesnake",
                    Artist = "Whitesnake",
                    Year = 1987
                },

                new Album {
                    Id = 12,
                    Title = "Long Cold Winter",
                    Artist = "Cinderella",
                    Year = 1988
                },

                new Album
                {
                    Id = 13,
                    Title = "Out of the Blue",
                    Artist = "Debbie Gibson",
                    Year = 1987
                },

                new Album
                {
                    Id = 14,
                    Title = "Slave to the Grind",
                    Artist = "Skid Row",
                    Year = 1991
                },

                new Album
                {
                    Id = 15,
                    Title = "Stay Hungry",
                    Artist = "Twisted Sister",
                    Year = 1984
                }
            };
        }

       

    }

}