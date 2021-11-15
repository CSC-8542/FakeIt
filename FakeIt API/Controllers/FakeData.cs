using FakeIt_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeIt_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FakeData : ControllerBase
    {
        public FakeData()
        {
        }

        [HttpGet]
        public List<Persona> Get(int quantity =1)
        {
            return GetPersona(quantity);
        }

        private List<Persona> GetPersona(int quantity)
        {
            List<Persona> persona = new();

            persona.Add(new Persona { Email = "nick@villanova.edu", FirstName = "Nick", LastName = "Langan", UserName = "nlangan",
                ImageURL = "https://media.istockphoto.com/photos/home-office-picture-id1193214720" }
            );

            return persona;
        }
    }
}
