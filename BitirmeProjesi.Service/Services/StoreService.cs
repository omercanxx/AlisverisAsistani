using AutoMapper;
using BitirmeProjesi.API.Exceptions;
using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using BitirmeProjesi.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BitirmeProjesi.Core.DTOs.ScanDtos;

namespace BitirmeProjesi.Service.Services
{
    public class StoreService : CustomService<Store>, IStoreService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public StoreService(IUnitOfWork unitOfWork, ICustomRepository<Store> repository, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper) : base(unitOfWork, repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<Store> GetWithCitiesByIdAsync(int storeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Store>> GetStoresWithProductsAsync(string productNo, int color, int size)
        {
            var dbProduct = await _unitOfWork.Products.GetProductAsync(productNo, color, size);
            return dbProduct.Product_Store.Select(x => x.Store).ToList();
        }
        public async Task<StoreScanDto> GetStoresWithBarcode(string barcode, double longtitude, double latitude)
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


            var x = await _unitOfWork.Stores.GetWithProductsByIdAsync(dbClosestStore.Id, dbProduct.ProductNo);

            var scanDto = _mapper.Map<StoreScanDto>(x);
            if (_httpContextAccessor.HttpContext.User.Identity.Name != null)
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

                foreach (var item in scanDto.Products)
                {
                    foreach (var i in item.Favorites)
                    {
                        if (i.UserId == dbUser.Id)
                            item.Liked = true;
                    }
                }
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




            await _unitOfWork.CommitAsync();

            return scanDto;
        }
    }
}
