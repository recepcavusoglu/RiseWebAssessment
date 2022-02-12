using AutoMapper;
using RiseWebAssessment.Model.DTO;

namespace RiseWebAssessment.Core
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDto, User>()
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
                );

            CreateMap<User, UserDto>()
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
                );



            
        }
    }
}
