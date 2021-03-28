using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Repositories
{
    public interface IProductCommentRepository : ICustomRepository<ProductComment>
    {
        Task<ProductComment> GetWithProductByIdAsync(Guid productCommentId);
    }
}