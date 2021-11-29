using FakeIt_API.Entities;
using System.Collections.Generic;

namespace FakeIt_API.Services.ResponseMapper
{
    public interface IFakerResponseMapper
    {
        public List<Persona> GetMappedPersona(Datum[] data);
    }
}
