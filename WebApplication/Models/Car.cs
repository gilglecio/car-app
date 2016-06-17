namespace WebApplication.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
