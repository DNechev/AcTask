using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsscorTask.Models
{
    public class ColorInputModel
    {
        [Required]
        public string Color { get; set; }
    }
}
