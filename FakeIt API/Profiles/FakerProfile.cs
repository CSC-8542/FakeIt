
using AutoMapper;
using FakeIt_API.Entities;

namespace FakeIt_API.Profiles
{
    public class FakerProfile : Profile
    {
        public FakerProfile()
        {
            CreateMap<Datum, Persona>()
                .ForMember(c => c.ImageURL, opt => opt.MapFrom(c => c.Image));
        }
    }
}
