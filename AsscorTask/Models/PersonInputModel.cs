using System.ComponentModel.DataAnnotations;

namespace AsscorTask.Models
{
    public class PersonInputModel
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int ColorId { get; set; }
    }
}
