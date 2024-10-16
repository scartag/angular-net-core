using System.ComponentModel.DataAnnotations;

namespace Contacts.Application.DTOs
{
    public class ContactDto
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
