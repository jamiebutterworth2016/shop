using DAL.DataModels;
using SharedResources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Abstractions.Repositories
{
    public interface IProductRepository
    {
        Task<Result<List<Product>>> GetProducts(CancellationToken cancellationToken);
    }
}