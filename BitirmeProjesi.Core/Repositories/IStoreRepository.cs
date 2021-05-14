using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Repositories
{
    public interface IStoreRepository :ICustomRepository<Store>
    {
        Task<Store> GetWithProductsByIdAsync(Guid storeId, string productNo);
        Task<Store> GetClosestStoreAsync(IEnumerable<Store> stores, double longtitude, double latitude);
    }
}
