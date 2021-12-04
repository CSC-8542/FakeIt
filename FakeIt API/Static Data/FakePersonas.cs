using FakeIt_API.Entities;
using System.Collections.Generic;

namespace FakeIt_API.Static_Data
{
    public class FakePersonas
    {
        public static List<Persona> GetPersonas()
        {
            List<Persona> persona = new();

            persona.Add(new Persona
            {
                Email = "nick@villanova.edu",
                FirstName = "Nick",
                LastName = "Langan",
                UserName = "nlangan",
                ImageURL = "https://media.istockphoto.com/photos/home-office-picture-id1193214720"
            }
            );

            return persona;
        }
    }
}
