using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Contracts
{
    public interface IGameRepository : IRepository<Game>
    {
        IEnumerable<Game> GetWithKeys(Expression<Func<Game, bool>> predicate);
        IEnumerable<Game> GetWithImages(Func<Game, bool> predicate);
        Task<IEnumerable<Game>> GetAllWithImages();
        Task<Game> GetOneWithImages(Expression<Func<Game, bool>> predicate);
        IEnumerable<Game> GetRandomWithImages(int quantity = 1);
    }
}
