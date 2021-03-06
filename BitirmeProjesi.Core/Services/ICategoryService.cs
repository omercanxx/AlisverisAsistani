using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Services
{
    public interface ICategoryService : ICustomService<Category>
    {
        Task<Category> GetWithProductTypesByIdAsync(Guid categoryId);
        Task<Category> GetWithProductsByIdAsync(Guid categoryId);
    }
}
