using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(WiredContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Game>> GetAllWithImages()
        {
            //var games = (from g in _context.Games
            //             join img in _context.Images on g.Id equals img.GameId
            //             join genre in _context.Genres on g.GenreId equals genre.Id
            //             select new Game()
            //             {
            //                 Id = g.Id,
            //                 Name = g.Name,
            //                 Price = g.Price,
            //                 Producer = g.Producer,
            //                 ReleaseYear = g.ReleaseYear,
            //                 Description = g.Description,
            //                 Keys = g.Keys,
            //                 GenreId = g.GenreId,
            //                 Genre = g.Genre,
            //                 Images = g.Images
            //             })
            //             .ToList();

            var games = await _context.Games
                .Include(g => g.Genre)
                .Include(g => g.Images)
                .ToListAsync();

            return games;
        }

        public async Task<Game> GetOneWithImages(Expression<Func<Game, bool>> predicate)
        {
            return await _context.Games
                .Include(g => g.Genre)
                .Include(g => g.Images)
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<Game> GetRandomWithImages(int quantity = 1)
        {
            return _context.Games
                .Include(g => g.Images)
                .OrderBy(r => Guid.NewGuid()).Take(quantity);
        }

        public IEnumerable<Game> GetWithImages(Func<Game, bool> predicate)
        {
            return _context.Games
                  .Include(g => g.Images)
                  .Include(g => g.Genre)
                  .Where(predicate).Distinct().ToList();
        }

        public IEnumerable<Game> GetWithKeys(Expression<Func<Game, bool>> predicate)
        {
            var games = (from g in _context.Games
                         join img in _context.Images on g.Id equals img.GameId
                         join genre in _context.Genres on g.GenreId equals genre.Id
                         join key in _context.GameKeys on g.Id equals key.GameId
                         select new Game()
                         {
                             Id = g.Id,
                             Name = g.Name,
                             Price = g.Price,
                             Producer = g.Producer,
                             ReleaseYear = g.ReleaseYear,
                             ShortDescription = g.ShortDescription,
                             Description = g.Description,
                             Keys = g.Keys,
                             GenreId = g.GenreId,
                             Genre = g.Genre,
                             Images = g.Images
                         })
                         .ToList();

            return games;
        }
    }
}
