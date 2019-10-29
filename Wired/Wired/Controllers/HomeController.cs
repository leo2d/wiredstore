using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wired.Data.Repository.Contracts;
using Wired.Models;

namespace Wired.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public HomeController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IActionResult Index()
        {
            try
            {
                var games = _gameRepository.GetRandomWithImages(30);
                games = games.OrderBy(g => Guid.NewGuid()).ToList();

                return View(games);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View("Error");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
