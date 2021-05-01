using BitirmeProjesi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IUserRepository Users { get; }
        IProductCommentRepository ProductComments { get; }
        IProduct_ImageRepository Product_Images { get; }
        IImageRepository Images { get; }
        IProduct_StoreRepository Product_Stores{ get; }
        IUser_FavoriteProductRepository User_FavoriteProducts { get; }
        IStoreRepository Stores { get; }
        Task CommitAsync();
        void Commit();
    }
}
