using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.UnitOfWorks;
using BitirmeProjesi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        private UserRepository _userRepository;
        private ProductCommentRepository _productCommentRepository;
        private Product_ImageRepository _product_ImageRepository;
        private Product_StoreRepository _product_StoreRepository;
        private User_FavoriteProductRepository _user_FavoriteProductRepository;
        private StoreRepository _storeRepository;
        private ImageRepository _imageRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public IProductCommentRepository ProductComments => _productCommentRepository  = _productCommentRepository ?? new ProductCommentRepository(_context);
        public IProduct_ImageRepository Product_Images => _product_ImageRepository = _product_ImageRepository ?? new Product_ImageRepository(_context);
        public IImageRepository Images => _imageRepository = _imageRepository ?? new ImageRepository(_context);
        public IProduct_StoreRepository Product_Stores => _product_StoreRepository = _product_StoreRepository ?? new Product_StoreRepository(_context);
        public IUser_FavoriteProductRepository User_FavoriteProducts => _user_FavoriteProductRepository= _user_FavoriteProductRepository ?? new User_FavoriteProductRepository(_context);
        public IStoreRepository Stores => _storeRepository = _storeRepository ?? new StoreRepository(_context);
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

