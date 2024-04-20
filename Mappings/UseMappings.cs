using AutoMapper;
using SaleOfProductsJWT.Contracts;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Models.UserDTO;

namespace SaleOfProductsJWT.Mappings
{
    public class UseMappings : Profile
    {

        public UseMappings()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<User, RequestCreateUser>();

        }
    }
}
