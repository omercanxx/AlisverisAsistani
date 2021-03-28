using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Services
{
    public interface IProductCommentService : ICustomService<ProductComment>
    {
        Task<ProductComment> GetWithProductByIdAsync(Guid productId);
        Task<ProductComment> Save(Guid productId, string Comment, bool IsAnonym);
    }
}