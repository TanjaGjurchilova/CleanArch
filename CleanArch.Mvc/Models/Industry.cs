using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Mvc.Models
{
    public class Industry
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
