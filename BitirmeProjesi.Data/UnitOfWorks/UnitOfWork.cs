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
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public IProductCommentRepository ProductComments => _productCommentRepository  = _productCommentRepository ?? new ProductCommentRepository(_context);

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

