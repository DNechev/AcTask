using System;
using System.Collections.Generic;
using System.Text;

namespace AssecorTask.Application.Models
{
    public class CreatePersonServiceModel
    {
        public string LastName { get; set; }

        public string Name { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public int ColorId { get; set; }
    }
}
