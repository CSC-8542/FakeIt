using FakeIt_API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeIt_API.Services.API_Communicator
{
    public interface IDataAccessor
    {
        public Task<List<Persona>> GetPersonas(PersonaQuery query);
    }
}
