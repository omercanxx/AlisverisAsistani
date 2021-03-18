using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Service.Services
{
    public class CategoryService : CustomService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, ICustomRepository<Category> repository) : base(unitOfWork, repository)
        {
        }
        public async Task<Category> GetWithProductsByIdAsync(Guid categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }

        public async Task<Category> GetWithProductTypesByIdAsync(Guid categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductTypesByIdAsync(categoryId);
        }
    }
}
