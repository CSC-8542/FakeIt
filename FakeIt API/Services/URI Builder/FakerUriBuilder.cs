using FakeIt_API.Entities;
using System;
using System.Collections.Generic;

namespace FakeIt_API.Services.URIBuilder
{
    public class FakerUriBuilder : IURIBuilder
    {
        private const string BaseURIOfFakerAPI = "https://fakerapi.it/api/v1/";
        private const string FakerAPIRequestType = "persons?";
        private const string QuantityURI = "?_quantity";
        private const string GenderURI = "?_gender";



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
            List<string> queryParams = GenerateQueryParams(query);

            foreach (string param in queryParams)
            {
                AddToURI(baseURI, param);

            }





            return baseURI;
        }

        private void AddToURI(string baseURI, string param)
        {
            if (param.Contains("gender"))
            {
                baseURI = baseURI + GenderURI + '=' + param;
            }

            if (param.Contains("quantity"))
            {
                baseURI = baseURI + QuantityURI + '=' + param;
            }
        }

        private List<string> GenerateQueryParams(PersonaQuery query)
        {
            return AssessQuery(query);
        }

        private List<string> AssessQuery(PersonaQuery query)
        {
            List<string> propertyList = new List<string>();
            if (query != null)
            {
                foreach (var prop in query.GetType().GetProperties())
                {
                    propertyList.Add(prop.Name);
                }
            }
            return propertyList;
        }

        private static char AddAmpresand()
        {
            return '&';
        }





    }
}
