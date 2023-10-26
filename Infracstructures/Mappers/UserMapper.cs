
using AutoMapper;
using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Mappers
{
    public partial class MapperConfigs : Profile
    {
        void UserMapperConfigs()
        {
            /*SAMPLE
                CreateMap<User, UserDetailModel>()
                .ForMember(des => des.Role, src => src.MapFrom(x => x.Role.Name))
                .ForMember(des => des.DateOfBirth, src => src.MapFrom(x => x.DateOfBirth.ToString("dd/MM/yyyy")))
                .ForMember(des => des.Status,
                    act => act.MapFrom(src => (UserStatus)Enum.Parse(typeof(UserStatus), src.Status)))
                .ForMember(des => des.Role, src => src.MapFrom(x => x.Role.Name));*/

        }
    }
}
