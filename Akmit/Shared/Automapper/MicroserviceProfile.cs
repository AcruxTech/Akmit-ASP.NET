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

            CreateMap<LessonRto, LessonInformationBlo>()
                .ForMember(x => x.Number, x => x.MapFrom(m => m.Number))
                .ForMember(x => x.Lesson, x => x.MapFrom(m => m.Lesson))
                .ForMember(x => x.Homework, x => x.MapFrom(m => m.Homework))
                .ForMember(x => x.Cabinet, x => x.MapFrom(m => m.Cabinet));

            CreateMap<LessonIdentityDto, LessonInformationBlo>()
                .ForMember(x => x.Number, x => x.MapFrom(m => m.Number))
                .ForMember(x => x.Lesson, x => x.MapFrom(m => m.Lesson))
                .ForMember(x => x.Homework, x => x.MapFrom(m => m.Homework))
                .ForMember(x => x.Cabinet, x => x.MapFrom(m => m.Cabinet));

            CreateMap<LessonInformationBlo, LessonInformationDto>()
                .ForMember(x => x.Number, x => x.MapFrom(m => m.Number))
                .ForMember(x => x.Lesson, x => x.MapFrom(m => m.Lesson))
                .ForMember(x => x.Homework, x => x.MapFrom(m => m.Homework))
                .ForMember(x => x.Cabinet, x => x.MapFrom(m => m.Cabinet));

            CreateMap<LessonUpdateDto, LessonUpdateBlo>()
                .ForMember(x => x.NewNumber, x => x.MapFrom(m => m.NewNumber))
                .ForMember(x => x.NewLesson, x => x.MapFrom(m => m.NewLesson))
                .ForMember(x => x.NewHomework, x => x.MapFrom(m => m.NewHomework))
                .ForMember(x => x.NewCabinet, x => x.MapFrom(m => m.NewCabinet));
        }
    }
}
