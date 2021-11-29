using FakeIt_API.Entities;
using System;
using System.Collections.Generic;
using System.Web;

namespace FakeIt_API.Services.URIBuilder
{
    public class FakerUriBuilder : IURIBuilder
    {
        private const string BaseURIOfFakerAPI = "https://fakerapi.it/api/v1/";
        private const string FakerAPIRequestType = "users";

        Dictionary<String, String> queryParamDictionary = new() { { "Quantity", "_quantity" }, { "Gender", "_gender" } };

        public FakerUriBuilder()
        {
        }

        public string GetPersonaUri(PersonaQuery query)
        {

            String baseURI = BaseURIOfFakerAPI + FakerAPIRequestType;

            var uriBuilder = new UriBuilder(baseURI);
            var uriQuery = HttpUtility.ParseQueryString(uriBuilder.Query);              

            Dictionary<string, string> queryParams = GenerateQueryParamAndValue(query);

            foreach (string param in queryParams.Keys)            {

                uriQuery[queryParamDictionary.GetValueOrDefault(param)] = queryParams.GetValueOrDefault(param);             

            }

            uriBuilder.Query = uriQuery.ToString();

            return uriBuilder.ToString();

        }          

   
        private Dictionary<string, string> GenerateQueryParamAndValue(PersonaQuery query)
        {
            Dictionary<string, string> queryMap = new();
            if (query != null)
            {
                foreach (var prop in query.GetType().GetProperties())
                {

                    var type = prop.PropertyType;
                    object defaultValue = type.IsValueType ? Activator.CreateInstance(type) : null;
                    if (prop.GetValue(query) != defaultValue)
                    {
                        queryMap.Add(prop.Name, prop.GetValue(query).ToString());
                    }
                }
            }
            return queryMap;
        }

    }
}
