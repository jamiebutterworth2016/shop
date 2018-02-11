using AutoMapper;
using BLL.Models;

namespace BLL.MapperProfiles
{
    public class ProductDataModelToProductProfile : Profile
    {
        public ProductDataModelToProductProfile()
        {
            CreateMap<DAL.DataModels.Product, Product>();
        }
    }
}