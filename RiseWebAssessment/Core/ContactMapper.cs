using RiseWebAssessment.Model;
using RiseWebAssessment.Model.DTO;
using AutoMapper;
namespace RiseWebAssessment.Core
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<ContactDto, Contact>()
              .ForMember(
                dest => dest.Id,
                from => from.MapFrom(x => x.Id)
              )
              .ForMember(
                dest => dest.InfoType,
                from => from.MapFrom(x => x.InfoType)
              )
              .ForMember(
                dest => dest.InfoContent,
                from => from.MapFrom(x => $"{x.InfoContent}")
              );

            CreateMap<Contact, ContactDto>()
              .ForMember(
                dest => dest.Id,
                from => from.MapFrom(x => x.Id)
              )
              .ForMember(
                dest => dest.InfoType,
                from => from.MapFrom(x => x.InfoType)
              )
              .ForMember(
                dest => dest.InfoContent,
                from => from.MapFrom(x => $"{x.InfoContent}")
              );
        }

    }
}