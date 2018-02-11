using AutoMapper;
using BLL.Abstractions.Services;
using BLL.Models;
using DAL.Abstractions.Repositories;
using SharedResources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Concretions.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<Product>>> GetProducts(CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetProducts(cancellationToken);

            if (!result.Success) return new Result<List<Product>>(result.Error);

            var mappedProducts = _mapper.Map<List<Product>>(result.Value);

            return new Result<List<Product>>(mappedProducts);
        }
    }
}