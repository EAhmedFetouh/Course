using System.ComponentModel.DataAnnotations;

namespace TranningApp.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }
    }
}