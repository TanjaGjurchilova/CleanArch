using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Mvc.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
