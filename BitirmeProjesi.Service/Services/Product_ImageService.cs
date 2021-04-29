using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Service.Services
{
    public class Product_ImageService : CustomService<Product_Image>, IProduct_ImageService
    {
        public Product_ImageService(IUnitOfWork unitOfWork, ICustomRepository<Product_Image> repository) : base(unitOfWork, repository)
        {
        }
    }
}
