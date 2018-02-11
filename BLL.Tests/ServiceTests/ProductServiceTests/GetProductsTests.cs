using AutoFixture;
using AutoMapper;
using AutoMoq;
using BLL.Concretions.Services;
using BLL.Models;
using DAL.Abstractions.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Tests.ServiceTests.ProductServiceTests
{
    public class GetProductsTests
    {
        private Mock<IProductRepository> _productRepository;
        private Mock<IMapper> _mapper;
        private List<Product> _mappedProducts;
        private Result<List<Product>> _result;

        [OneTimeSetUp]
        public async Task GivenAProductService_WhenGettingProducts()
        {
            var moqer = new AutoMoqer();
            var productService = moqer.Create<ProductService>();
            _productRepository = moqer.GetMock<IProductRepository>();
            _mapper = moqer.GetMock<IMapper>();

            var fixture = new Fixture();
            var cancellationToken = new CancellationToken();

            var productDataModelsResult = new Result<List<DAL.DataModels.Product>>(fixture.CreateMany<DAL.DataModels.Product>().ToList());
            _productRepository.Setup(x => x.GetProducts(cancellationToken)).Returns(Task.FromResult(productDataModelsResult)).Verifiable();

            _mappedProducts = fixture.CreateMany<Product>().ToList();
            _mapper.Setup(x => x.Map<List<Product>>(productDataModelsResult.Value)).Returns(_mappedProducts).Verifiable();

            _result = await productService.GetProducts(cancellationToken);
        }

        [Test]
        public void ThenTheProductDataModelsAreReturned() => _productRepository.Verify();

        [Test]
        public void ThenTheProductDataModelsAreMappedToProducts() => _mapper.Verify();

        [Test]
        public void ThenTheResultIsReturned() => _result.Value.Should().BeEquivalentTo(_mappedProducts);
    }
}