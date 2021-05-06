using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Services
{
    public interface IProductCommentService : ICustomService<ProductComment>
    {
        Task<List<ProductComment>> GetWithUserByIdAsync(Guid productId);
        Task<ProductComment> Save(Guid productId, string Comment, bool IsAnonym);
        Task<Guid> RemoveProductComment(Guid productCommentId);
    }
}