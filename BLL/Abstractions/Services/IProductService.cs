using BLL.Models;
using SharedResources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Abstractions.Services
{
    public interface IProductService
    {
        Task<Result<List<Product>>> GetProducts(CancellationToken cancellationToken);
    }
}