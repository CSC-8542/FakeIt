using System;
using System.Collections.Generic;
using FakeIt_API.Entities;

namespace FakeIt_API.Services.URIBuilder
{
    public class URIBuilder : IURIBuilder
    {
        private const string BaseURIOfFakerAPI = "https://fakerapi.it/api/v1/";
        private const string FakerAPIRequestType = "persons?";
        private const string QuantityURI = "?_quantity";
        private const string GenderURI = "?_gender";



        public URIBuilder()
        {
        }

        public string GetURI(Query query)
        {
            String baseURI = BaseURIOfFakerAPI + FakerAPIRequestType;

            return MeshURI(baseURI, query);


        }

        private string MeshURI(string baseURI, Query query)
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

        private List<string> GenerateQueryParams(Query query)
        {
            return AssessQuery(query);
        }

        private List<string> AssessQuery(Query query)
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
