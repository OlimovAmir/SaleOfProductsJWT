using AutoMapper;
using SaleOfProductsJWT.Models.UserDTO;

namespace SaleOfProductsJWT.Mappings
{
    public class UseMappings : Profile
    {

        public UseMappings()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            // Добавьте другие настройки для остальных полей
        }
    }
}
