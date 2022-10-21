using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TranningApp.API.Models
{
    public class Value
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
    }
}