using AdvertisingAgency.Contracts.Responses;
using AutoMapper;
using IdentityMicroservice.DAL.Models;

namespace IdentityMicroservice.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GetCurrentUserResponse>();
        }
    }
}
