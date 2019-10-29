using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;

namespace Wired.Data.Repository.Repository
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(WiredContext context) : base(context)
        {
        }
    }
}
