using AutoFixture;
using AutoMapper;
using BLL.MapperProfiles;
using BLL.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BLL.Tests.MapperTests
{
    public class ProductDataModelToProductProfileTests
    {
        private IMapper _mapper;
        private DAL.DataModels.Product _productDataModel;
        private Product _product;

        [OneTimeSetUp]
        public void GivenALoadedMapper_WhenMappingAProductDataModelToAProduct()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<ProductDataModelToProductProfile>()).CreateMapper();
            _productDataModel = new Fixture().Create<DAL.DataModels.Product>();
            _product = _mapper.Map<Product>(_productDataModel);
        }

        [Test]
        public void ThenTheConfigurationIsValid() =>
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();

        [Test]
        public void ThenTheMapIsSuccessful() =>
            _product.Should().BeEquivalentTo(_productDataModel);
    }
}