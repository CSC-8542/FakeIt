using FakeIt_API.Entities;
using System;
using System.Collections.Generic;

namespace FakeIt_API.Services.URIBuilder
{
    public class FakerUriBuilder : IURIBuilder
    {
        private const string BaseURIOfFakerAPI = "https://fakerapi.it/api/v1/";
        private const string FakerAPIRequestType = "persons";
        private const string QuantityURI = "?_quantity";
        private const string GenderURI = "?_gender";


        Dictionary<String, String> queryParamDictionary = new() { { "Quantity", "_quantity" }, {"Gender", "_gender"} };

       

        public FakerUriBuilder()
        {
        }

        public string GetPersonaUri(PersonaQuery query)
        {
            String baseURI = BaseURIOfFakerAPI + FakerAPIRequestType;

            return MeshURI(baseURI, query);


        }

        private string MeshURI(string baseURI, PersonaQuery query)
        {
            Dictionary<string, string> queryParams = GenerateQueryParams(query);

            //ToDo: Hashmap, list of possible FakeIt parameters

          


            foreach (string param in queryParams.Keys)
            {
               

                AddToURI(baseURI, queryParamDictionary.GetValueOrDefault(param), queryParams.GetValueOrDefault(param));

            }





            return baseURI;
        }

        private void AddToURI(string baseURI, string param, String paramValue)
        {
                        
            baseURI = baseURI + "?" + param + "=" + paramValue;
         }
          
        

        private Dictionary<string, string> GenerateQueryParams(PersonaQuery query)
        {
            return AssessQuery(query);
        }

        private Dictionary<string, string> AssessQuery(PersonaQuery query)
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

        private static char AddAmpresand()
        {
            return '&';
        }       





    }
}
