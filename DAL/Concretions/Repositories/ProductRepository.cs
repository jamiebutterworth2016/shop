using DAL.Abstractions.Helpers;
using DAL.Abstractions.Repositories;
using DAL.DataModels;
using SharedResources;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Concretions.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICurrentContext _currentContext;

        public ProductRepository(ICurrentContext currentContext)
        {
            _currentContext = currentContext ?? throw new ArgumentNullException();

            if (_currentContext.Context == null) _currentContext.Create();
        }

        public async Task<Result<List<Product>>> GetProducts(CancellationToken cancellationToken)
        {
            if (cancellationToken == null) throw new ArgumentNullException();

            var products = await _currentContext.Context.Products.ToListAsync(cancellationToken);

            var result = new Result<List<Product>>(products);

            return result;
        }
    }
}