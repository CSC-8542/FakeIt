


using FakeIt_API.Entities;
using FakeIt_API.Services.ResponseMapper;
using FakeIt_API.Services.URIBuilder;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FakeIt_API.Services.API_Communicator
{
    public class FakeItDataAccessor : IDataAccessor
    {
        private readonly IURIBuilder _builder;
        private readonly IHttpClientFactory _client;
        private readonly IFakerResponseMapper _mapper;

        public FakeItDataAccessor(IURIBuilder builder, IHttpClientFactory client, IFakerResponseMapper mapper)
        {
            _builder = builder;
            _client = client;
            _mapper = mapper;

        }

        [System.Obsolete]
        public async Task<List<Persona>> GetPersonasAsync(PersonaQuery query)
        {
            var url = _builder.GetPersonaUri(query);
            //Root fakerData = new Root();
            Rootobject fakerData = new Rootobject();
            var httpClient = _client.CreateClient();
            var response = await httpClient.GetAsync(url);


            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                fakerData = JsonConvert.DeserializeObject<Rootobject>(apiResponse);
                return _mapper.GetMappedPersona(fakerData.Data);
            }


            return null;

        }
    }
}

