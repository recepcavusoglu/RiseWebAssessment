using AutoMapper;
using RiseWebAssessment.Model.DTO;

namespace RiseWebAssessment.Core
{
    public class UserWithContactMapper : Profile
    {
        public UserWithContactMapper()
        {
            CreateMap<UserWithContactDto, User>()
                .ForMember(
                    dest => dest.Id,
                    from => from.MapFrom(x => x.Id)
                )
                .ForMember(
                    dest => dest.FirstName,
                    from => from.MapFrom(x => $"{x.FirstName}")
                )
                .ForMember(
                    dest => dest.LastName,
                    from => from.MapFrom(x => $"{x.LastName}")
                )
                .ForMember(
                    dest => dest.Company,
                    from => from.MapFrom(x => $"{x.Company}")
                ).ForMember(
                    dest => dest.Contact,
                    from => from.MapFrom(x => x.Contact)
                ); 

            CreateMap<User, UserWithContactDto>()
                .ForMember(
                    dest => dest.Id,
                    from => from.MapFrom(x => x.Id)
                )
                .ForMember(
                    dest => dest.FirstName,
                    from => from.MapFrom(x => $"{x.FirstName}")
                )
                .ForMember(
                    dest => dest.LastName,
                    from => from.MapFrom(x => $"{x.LastName}")
                )
                .ForMember(
                    dest => dest.Company,
                    from => from.MapFrom(x => $"{x.Company}")
                ).ForMember(
                    dest => dest.Contact,
                    from => from.MapFrom(x => x.Contact)
                );
        }
        
    }
}
