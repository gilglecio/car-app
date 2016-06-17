using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Car Car { get; set; }
    }
}
