using System;
using FakeIt_API.Entities;

namespace FakeIt_API.Services.URIBuilder
{
    public class URIBuilder : IURIBuilder
    {
        private const string baseURIOfFakerAPI = "https://fakerapi.it/api/v1/";
        private const string fakerAPIRequestType = "persons?"; 
        private const string quantityURI = "?_quantity";
        private const string genderURI = "?_gender";
        private const string birthdayStartURI = "?_birthday_start";
        private Random gen = new Random();


        public URIBuilder()
        {
        }

        public string GetURI(Query query)
        {
            String baseURI = baseURIOfFakerAPI;

            return MeshURI(baseURI, query);


        }

        private string MeshURI(string baseURI, Query query)
        {
            String builtURI = baseURI + fakerAPIRequestType + AssessQuantity(query) + AddAmpresand() + AssessGender(query) + AddAmpresand() + AssessBirthdayStart(query);

            return builtURI;
        }

        private string AssessBirthdayStart(Query query)
        {
            return birthdayStartURI + "=" + RandomDay();
        }

        private static char AddAmpresand()
        {
            return '&';
        }

        private string AssessGender(Query query)
        {
            return genderURI + "=" + "male";
        }

        private string AssessQuantity(Query query)
        {

            return quantityURI + "=" + query.Quantity;
        }


        DateTime RandomDay()
        {
            DateTime start = GetStart();
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));

            static DateTime GetStart()
            {
                return new DateTime(1940, 1, 1);
            }
        }
    }
}
