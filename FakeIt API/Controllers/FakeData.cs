using FakeIt_API.Entities;
using FakeIt_API.Services.API_Communicator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FakeIt_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FakeData : ControllerBase
    {
        private readonly IDataAccessor _dataAccessor;

        public FakeData(IDataAccessor dataAccessor)
        {
            _dataAccessor = dataAccessor;
        }

        [HttpGet]
        public List<Persona> Get([FromQuery] PersonaQuery query)
        {
            return _dataAccessor.GetPersonas(query);
        }

    }
}
