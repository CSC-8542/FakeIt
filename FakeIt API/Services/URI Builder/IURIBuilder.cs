using FakeIt_API.Entities;
using System;

namespace FakeIt_API.Services.URIBuilder
{
    public interface IURIBuilder
    {
        public String GetPersonaUri(PersonaQuery query);
    }
}
