using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(WiredContext context) : base(context)
        {
        }
    }
}
