using FakeIt_API.Entities;
using System.Collections.Generic;

namespace FakeIt_API.Services.API_Communicator
{
    public interface IDataAccessor
    {
        public List<Persona> GetPersonas(PersonaQuery query);
    }
}
