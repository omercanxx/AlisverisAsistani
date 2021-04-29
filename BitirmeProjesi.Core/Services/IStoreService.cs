using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Services
{
    public interface IStoreService : ICustomService<Store>
    {
        Task<Store> GetWithProductsByIdAsync(int storeId);
        Task<Store> GetWithCitiesByIdAsync(int storeId);
        Task<Store> GetStoresWithBarcode(string barcode, double longtitude, double latitude);
    }
}
