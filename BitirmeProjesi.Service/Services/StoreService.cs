using BitirmeProjesi.API.Exceptions;
using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Service.Services
{
    public class StoreService : CustomService<Store>, IStoreService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StoreService(IUnitOfWork unitOfWork, ICustomRepository<Store> repository, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager) : base(unitOfWork, repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public Task<Store> GetWithCitiesByIdAsync(int storeId)
        {
            throw new NotImplementedException();
        }

        public Task<Store> GetWithProductsByIdAsync(int storeId)
        {
            throw new NotImplementedException();
        }
        public async Task<Store> GetStoresWithBarcode(string barcode, double longtitude, double latitude)
        {
            //Store Bilgisi
            var dbStores = await _unitOfWork.Products.GetStoresWithBarcode(barcode);
            var dbClosestStore = await _unitOfWork.Stores.GetClosestStoreAsync(dbStores, longtitude, latitude);
            if (dbClosestStore == null)
                throw new CustomException("Mağaza bulunamadı");

            //Product Bilgisi
            var dbProduct = await _unitOfWork.Products.GetProductByBarcodeAsync(barcode);
            if (dbProduct == null)
                throw new CustomException("Ürün bulunamadı");

            if(_httpContextAccessor.HttpContext.User.Identity.Name != null)
            {
                var dbUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name);
                if (dbUser == null)
                    throw new CustomException("Kullanıcı bulunamadı");
                Scan scan = new Scan()
                {
                    StoreId = dbClosestStore.Id,
                    ProductId = dbProduct.Id,
                    UserId = dbUser.Id
                };
                await _unitOfWork.Scans.AddAsync(scan);
            }
            //User Bilgisi
            else
            {
                Scan scan = new Scan()
                {
                    StoreId = dbClosestStore.Id,
                    ProductId = dbProduct.Id
                };
                await _unitOfWork.Scans.AddAsync(scan);
            }

            //Logging


            
            await _unitOfWork.CommitAsync();


            return await _unitOfWork.Stores.GetWithProductsByIdAsync(dbClosestStore.Id, dbProduct.ProductNo);
        }
    }
}
