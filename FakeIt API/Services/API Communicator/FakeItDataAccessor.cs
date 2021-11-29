


using FakeIt_API.Entities;
using FakeIt_API.Static_Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using FakeIt_API.Services.URIBuilder;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
//using ServiceStack;
using System.Net;
using static FakeIt_API.Entities.FakerPersona;

namespace FakeIt_API.Services.API_Communicator
{
    public class FakeItDataAccessor : IDataAccessor
    {

        static string _address = "https://fakerapi.it/api/v1/persons?_quantity=1&_gender=male&_birthday_start=2005-01-01";
        private readonly IURIBuilder builder;
        private readonly IHttpClientFactory client;

        public FakeItDataAccessor(IURIBuilder _builder, IHttpClientFactory _client)
        {
            builder = _builder;
            client = _client;

        }

        [System.Obsolete]
        public async Task<List<Persona>> GetPersonasAsync(PersonaQuery query)
        {
            var url = builder.GetPersonaUri(query);
            //Root fakerData = new Root();
            Root fakerData = new Root();
            var httpClient = client.CreateClient();
            var response = await httpClient.GetAsync(url);

            string apiResponse = await response.Content.ReadAsStringAsync();
            fakerData = JsonConvert.DeserializeObject<Root>(apiResponse);


            return fakerData;
        }
    }
}

