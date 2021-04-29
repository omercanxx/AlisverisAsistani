using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Repository
{
    class ImageRepository : CustomRepository<Image>, IImageRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
