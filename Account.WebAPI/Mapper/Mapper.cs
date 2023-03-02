using Account.Domain;
using Account.WebAPI.Models;
using AutoMapper;

namespace Account.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AccountDTO, Models.Account>();

            CreateMap<AccountCreateRequest, AccountDTO>();
                //.ForMember(dest => dest.FirstNamee, src => src.MapFrom(map => map.FirstName));
        }
    }
}
