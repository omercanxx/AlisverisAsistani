using BitirmeProjesi.Core.DTOs;
using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Services
{
    public interface IStoreService : ICustomService<Store>
    {
        Task<List<Store>> GetStoresWithProductsAsync(string productNo, int color, int size);
        Task<Store> GetWithCitiesByIdAsync(int storeId);
        Task<StoreScanDto> GetStoresWithBarcode(string barcode, double longtitude, double latitude);
    }
}
