using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public int? PackageId { get; set; }
        public Package? Package { get; set; }
        public Message()
        {

        }
    }
}
