namespace AssecorTask.Application.Models
{
    public class PersonServiceModel
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public int ColorId { get; set; }

        public ColorServiceModel Color { get; set; }
    }
}
