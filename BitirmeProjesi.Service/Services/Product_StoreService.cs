using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Service.Services
{
    public class Product_StoreService : CustomService<Product_Store>, IProduct_StoreService
    {
        public Product_StoreService(IUnitOfWork unitOfWork, ICustomRepository<Product_Store> repository) : base(unitOfWork, repository)
        {
        }
    }
}