using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;
using Wired.Models.ViewModels;

namespace Wired.Controllers
{
    public class SearchController : Controller
    {
        private IGameRepository _gameRepository;
        private IGenreRepository _genreRepository;

        public SearchController(IGameRepository gameRepository, IGenreRepository genreRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }

        public IActionResult List(string searchName)
        {
            if (String.IsNullOrEmpty(searchName) | String.IsNullOrWhiteSpace(searchName))
                return View("Error");
            try
            {
                searchName = searchName.Trim();
                var keyWords = searchName.Split(' ');

                var games = new List<Game>();

                foreach (var keyWord in keyWords)
                {
                    var result = _gameRepository
                    .GetWithImages(x => x.Name.Contains(keyWord, StringComparison.InvariantCultureIgnoreCase));

                    games = games.Union(result).ToList();
                }

                return View(GetAsViewGame(games));
            }
            catch (Exception e)
            {
                return View("Error");
                throw;
            }
        }

        public IActionResult SearchByGenre(int? id)
        {
            if (id != null)
            {
                try
                {
                    var games = _gameRepository.GetWithImages(x => x.GenreId == id);
                    return View("List", GetAsViewGame(games));
                }
                catch (Exception e)
                {
                    return View("Error");
                    throw;
                }
            }

            return View("List");
        }

        public async Task<IActionResult> Genres()
        {
            try
            {
                var genres = await _genreRepository.GetAll();

                return PartialView(genres);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<GameViewModel> GetAsViewGame(IEnumerable<Game> games)
        {
            var viewGames = new List<GameViewModel>();
            foreach (var game in games)
            {
                viewGames.Add
                    (
                        new GameViewModel()
                        {
                            Id = game.Id,
                            Name = game.Name,
                            Price = game.Price,
                            ShortDescription = game.ShortDescription,
                            Description = game.Description,
                            ReleaseYear = game.ReleaseYear,
                            Producer = game.Producer,
                            Genre = game.Genre.Name,
                            Images = game.Images
                        }
                    );
            }

            return viewGames;
        }
    }
}