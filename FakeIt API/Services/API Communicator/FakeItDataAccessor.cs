using FakeIt_API.Entities;
using FakeIt_API.Static_Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FakeIt_API.Services.API_Communicator
{
    public class FakeItDataAccessor : IDataAccessor
    {
        public FakeItDataAccessor()
        {
        }
        public List<Persona> GetPersonas([FromQuery] PersonaQuery query)
        {
            return FakePersonas.GetPersonas();
        }
    }
}
