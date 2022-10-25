using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TranningApp.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }= string.Empty;
        public  byte[]? PasswordHash { get; set; }=null;
        public byte[]? PasswordSalt { get; set; }=null;
    }
}