using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Service.Services
{
    public class ProductService : CustomService<Product>, IProductService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductService(IUnitOfWork unitOfWork, ICustomRepository<Product> repository, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager) : base(unitOfWork, repository)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await _unitOfWork.Products.GetProductAsync(productId);
            
        }
        public async Task<Product> GetWithCategoriesByIdAsync(Guid productId)
        {
            return await _unitOfWork.Products.GetWithCategoriesByIdAsync(productId);
        }

        public async Task<Product> GetWithCommentsByIdAsync(Guid productId)
        {
            return await _unitOfWork.Products.GetWithCommentsByIdAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetWithStoresByIdAsync(Guid productId)
        {
            return await _unitOfWork.Products.GetWithStoresByIdAsync(productId);
        }

        public async Task<Product> GetWithSupplementsByIdAsync(Guid productId)
        {
            return await _unitOfWork.Products.GetWithSupplementsByIdAsync(productId);
        }
        public async Task<Product> Save(Guid productTypeId, Guid storeId, IEnumerable<IFormFile> images, string name, int stock, int size, string barcode, string productNo, int color, decimal price)
        {

            var dbUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name);
            Product product = new Product()
            {
                UserId = dbUser.Id,
                ProductTypeId = productTypeId,
                Name = name,
                Stock = stock,
                Size = size,
                Price = price,
                Color = color,
                Barcode = barcode,
                ProductNo = productNo
            };
            await _unitOfWork.Products.AddAsync(product);

            Product_Store product_Store = new Product_Store()
            {
                ProductId = product.Id,
                StoreId = storeId
            };
            await _unitOfWork.Product_Stores.AddAsync(product_Store);


            if (images != null)
            {
                int sort = 1;
                foreach (var item in images)
                {
                    //Orjinal dosyamızın extensionunu alıyoruz
                    string extension = Path.GetExtension(item.FileName);
                    Guid imageId = Guid.NewGuid();
                    string p = $"{imageId}{extension}";
                    string path = Path.Combine("C:\\inetpub\\wwwroot\\AlisverisAsistani\\ProductImages\\" + p);
                    Image image = new Image()
                    {
                        Path = $"ProductImages\\{p}",
                        Sort = sort
                    };
                    await _unitOfWork.Images.AddAsync(image);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    sort++;

                    Product_Image product_Image = new Product_Image()
                    {
                        ProductId = product.Id,
                        ImageId = image.Id
                    };
                    await _unitOfWork.Product_Images.AddAsync(product_Image);
                }
            }

            await _unitOfWork.CommitAsync();
            return product;
        }
    }
}
