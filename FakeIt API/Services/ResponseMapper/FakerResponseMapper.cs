using AutoMapper;
using FakeIt_API.Entities;
using System.Collections.Generic;

namespace FakeIt_API.Services.ResponseMapper
{
    public class FakerResponseMapper : IFakerResponseMapper
    {
        private readonly IMapper _mapper;

        public FakerResponseMapper(IMapper mapper)
        {
            _mapper = mapper;

        }
        public List<Persona> GetMappedPersona(Datum[] data)
        {
            return _mapper.Map<List<Persona>>(data);
        }
    }
}
