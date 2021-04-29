using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Service.Services
{
    public class StoreService : CustomService<Store>, IStoreService
    {
        public StoreService(IUnitOfWork unitOfWork, ICustomRepository<Store> repository) : base(unitOfWork, repository)
        {
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
            var dbStores = await _unitOfWork.Products.GetStoresWithBarcode(barcode);
            var dbClosestStore = await _unitOfWork.Stores.GetClosestStoreAsync(dbStores, longtitude, latitude);
            return await _unitOfWork.Stores.GetWithProductsByIdAsync(dbClosestStore.Id);
        }
    }
}
