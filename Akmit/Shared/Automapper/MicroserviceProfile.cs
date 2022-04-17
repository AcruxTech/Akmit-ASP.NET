using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akmit.Shared.Automapper
{
    public class MicroserviceProfile : Profile
    {
        public MicroserviceProfile() {
            /*CreateMap<UserRto, UserInformationBlo>()
                .ForMember(x => x.Email, x => x.MapFrom(m => m.Email))
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login));*/
        }
    }
}
