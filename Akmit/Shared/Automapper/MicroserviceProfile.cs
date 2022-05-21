using Akmit.Api.Models;
using Akmit.BusinessLogic.Models;
using Akmit.DataAccess.Models;
using AutoMapper;

namespace Akmit.Shared.Automapper
{
    public class MicroserviceProfile : Profile
    {
        public MicroserviceProfile() {
            CreateMap<UserRto, UserInformationBlo>()
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Email, x => x.MapFrom(m => m.Email))
                .ForMember(x => x.Role, x => x.MapFrom(m => m.Role))
                .ForMember(x => x.Url, x => x.MapFrom(m => m.Url))
                .ForMember(x => x.ClassRtoId, x => x.MapFrom(m => m.ClassRtoId));

            CreateMap<UserRto, UserInformationShortBlo>()
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Url, x => x.MapFrom(m => m.Url))
                .ForMember(x => x.Role, x => x.MapFrom(m => m.Role));

            CreateMap<ClassRto, ClassInformationBlo>()
                .ForMember(x => x.Title, x => x.MapFrom(m => m.Title))
                .ForMember(x => x.SecretCode, x => x.MapFrom(m => m.SecretCode));

            CreateMap<UserIdentityBlo, UserIdentityDto>()
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Email, x => x.MapFrom(m => m.Email))
                .ForMember(x => x.Password, x => x.MapFrom(m => m.Password));

            CreateMap<UserInformationShortBlo, UserInformationShortDto>()
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Url, x => x.MapFrom(m => m.Url))
                .ForMember(x => x.Role, x => x.MapFrom(m => m.Role));

            CreateMap<UserInformationBlo, UserInformationDto>()
                .ForMember(x => x.Login, x => x.MapFrom(m => m.Login))
                .ForMember(x => x.Email, x => x.MapFrom(m => m.Email))
                .ForMember(x => x.Role, x => x.MapFrom(m => m.Role))
                .ForMember(x => x.Url, x => x.MapFrom(m => m.Url))
                .ForMember(x => x.ClassRtoId, x => x.MapFrom(m => m.ClassRtoId));

            CreateMap<ClassInformationBlo, ClassInformationDto>()
                .ForMember(x => x.Title, x => x.MapFrom(m => m.Title))
                .ForMember(x => x.SecretCode, x => x.MapFrom(m => m.SecretCode));

            CreateMap<DayRto, DayInformationBlo>()
                .ForMember(x => x.Title, x => x.MapFrom(m => m.Title))
                .ForMember(x => x.Pavilion, x => x.MapFrom(m => m.Pavilion));

            CreateMap<DayInformationBlo, DayInformationDto>()
                .ForMember(x => x.Title, x => x.MapFrom(m => m.Title))
                .ForMember(x => x.Pavilion, x => x.MapFrom(m => m.Pavilion));
        }
    }
}
