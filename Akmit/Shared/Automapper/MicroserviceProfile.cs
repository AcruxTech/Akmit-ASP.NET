﻿using Akmit.BusinessLogic.Models;
using Akmit.DataAccess.Models;
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
            CreateMap<UserRto, UserInformationBlo>()
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Email, x => x.MapFrom(m => m.Email))
                .ForMember(x => x.Role, x => x.MapFrom(m => m.Role))
                .ForMember(x => x.ClassRtoId, x => x.MapFrom(m => m.ClassRtoId));

            CreateMap<UserRto, UserInformationShortBlo>()
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Role, x => x.MapFrom(m => m.Role));
        }
    }
}
