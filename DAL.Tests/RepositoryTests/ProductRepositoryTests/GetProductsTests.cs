using AutoFixture;
using DAL.Concretions.Helpers;
using DAL.Concretions.Repositories;
using DAL.DataModels;
using Effort;
using FluentAssertions;
using NUnit.Framework;
using SharedResources;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Tests.RepositoryTests.ProductRepositoryTests
{
    public class GetProductsTests
    {
        private Product _product;
        private Result<List<Product>> _result;

        [OneTimeSetUp]
        public async Task GivenAProductRepository_WhenGettingProducts()
        {
            var cancellationToken = new CancellationToken();

            _product = new Fixture().Build<Product>().Without(x => x.Id).Create();

            using (var currentContext = new CurrentContext())
            {
                currentContext.CreateTransient();
                currentContext.Context.Products.Add(_product);
                await currentContext.Context.SaveChangesAsync(cancellationToken);

                _result = await new ProductRepository(currentContext).GetProducts(cancellationToken);
            }
        }

        [Test]
        public void ThenTheProductsAreReturned()
        {
            _result.Success.Should().BeTrue();
            _result.Value.Single().Should().BeEquivalentTo(_product);
        }
    }
}