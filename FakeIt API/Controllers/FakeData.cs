using FakeIt_API.Entities;
using FakeIt_API.Services.API_Communicator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<List<Persona>>> Get([FromQuery] PersonaQuery query)
        {
            var data = await _dataAccessor.GetPersonasAsync(query);
            if (data is null)
            {
                return NotFound();
            }
            return data;
        }

    }
}
