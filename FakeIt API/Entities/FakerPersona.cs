
namespace FakeIt_API.Entities
{
    public class Rootobject
    {
        public string Status { get; set; }
        public int Code { get; set; }
        public int Total { get; set; }
        public Datum[] Data { get; set; }
    }

    public class Datum
    {
        public string Uuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Ip { get; set; }
        public string MacAddress { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
    }
}