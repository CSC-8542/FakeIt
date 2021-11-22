using Microsoft.AspNetCore.Mvc;

namespace FakeIt_API.Entities
{
    public class PersonaQuery
    {
        [FromQuery(Name = "quantity")]
        public int Quantity { get; set; } = 1;
    }
}
