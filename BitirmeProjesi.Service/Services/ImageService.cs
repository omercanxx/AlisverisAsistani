using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Service.Services
{
    public class ImageService : CustomService<Image>, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork, ICustomRepository<Image> repository) : base(unitOfWork, repository)
        {
        }
    }
}

