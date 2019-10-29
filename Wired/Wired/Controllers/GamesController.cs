using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;
using Wired.Models.ViewModels;

namespace Wired.Controllers
{
    public class GamesController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IImageRepository _imageRepository;


        public GamesController(IGameRepository gameRepository, IGenreRepository genreRepository,
            IImageRepository imageRepository, IHostingEnvironment IHostingEnvironment)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _environment = IHostingEnvironment;
            _imageRepository = imageRepository;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var games = await _gameRepository
                .GetAllWithImages();

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

            return View(viewGames);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var game = await _gameRepository
              .GetOneWithImages(x => x.Id == id);

                if (game == null)
                {
                    return NotFound();
                }

                return View(game);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Games/Create
        public async Task<IActionResult> Create()
        {
            var genres = await _genreRepository.GetAll();

            ViewBag.Genres = genres;
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Game game, List<IFormFile> imgfiles)
        {
            if (ModelState.IsValid)
            {
                if (imgfiles != null && imgfiles.Count > 0)
                {
                    foreach (var image in imgfiles)
                    {
                        var imageName = GetUniqueFileName(image.FileName);
                        SaveGameImage(image, imageName);

                        game.Images.Add(new Image() { ImagePath = imageName });
                    }
                }
                else
                    game.Images.Add(new Image() { ImagePath = "imagem-nao-disponivel.jpg" });

                await _gameRepository.Create(game);

                return RedirectToAction(nameof(Index));
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameId = id ?? default(int);
            var game = await _gameRepository.GetOneWithImages(x => x.Id == gameId);

            if (game == null)
            {
                return NotFound();
            }

            ViewBag.Genres = await _genreRepository.GetAll();
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Game game, List<IFormFile> imgfiles)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var imagesToDelete = new List<Image>();
                    if (imgfiles != null && imgfiles.Count > 0)
                    {
                        var gameImages = await _imageRepository.Find(x => x.GameId == game.Id);
                        game.Images = gameImages.ToList();
                        game.Images.RemoveAll(i => i.ImagePath.Contains("imagem-nao-disponivel"));

                        foreach (var image in imgfiles)
                        {
                            var imageName = GetUniqueFileName(image.FileName);
                            SaveGameImage(image, imageName);

                            game.Images.Add(new Image() { ImagePath = imageName, Game = game, GameId = game.Id });
                        }

                        var df = gameImages.Where(i => i.ImagePath.Contains("imagem-nao-disponivel"));
                        imagesToDelete.AddRange(df);

                    }

                    try
                    {
                        if (imagesToDelete != null && imagesToDelete.Count > 0)
                            imagesToDelete.ForEach(img => _imageRepository.Delete(img).Wait());
                        await _gameRepository.Update(game);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!GameExists(game.Id).Result)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int gameId = id ?? default(int);
            var game = await _gameRepository.GetById(gameId);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _gameRepository.GetById(id);
            await _gameRepository.Delete(game);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> GameExists(int id)
        {
            return await _gameRepository.GetById(id) != null;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);

            return $"{Path.GetFileNameWithoutExtension(fileName)}_{Guid.NewGuid().ToString().Substring(0, 6)}{Path.GetExtension(fileName)}";
        }

        private void SaveGameImage(IFormFile image, string filename)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "images");
            var fullPath = Path.Combine(uploads, filename);

            using (FileStream fs = System.IO.File.Create(fullPath))
            {
                image.CopyTo(fs);
                fs.Flush();
            }
        }
    }
}
