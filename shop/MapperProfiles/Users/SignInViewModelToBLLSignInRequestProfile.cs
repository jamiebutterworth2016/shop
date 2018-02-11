using AutoMapper;
using BLL.Models;
using shop.Models.Users;

namespace shop.MapperProfiles.Users
{
    public class SignInViewModelToBLLSignInRequestProfile : Profile
    {
        public SignInViewModelToBLLSignInRequestProfile()
        {
            CreateMap<SignInViewModel, SignInRequest>();
        }
    }
}