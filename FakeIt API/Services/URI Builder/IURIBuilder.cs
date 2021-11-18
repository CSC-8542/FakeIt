using System;
using FakeIt_API.Entities;

namespace FakeIt_API.Services.URIBuilder
{
    public interface IURIBuilder
    {
        public String GetURI(Query query);
    }
}
