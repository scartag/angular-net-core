using Contacts.Application.DTOs;
using Contacts.Core.Entities;

namespace Contacts.Infrastructure.Mappings
{
    public static class Extensions
    {
        public static ContactDto AsDto(this Contact contact)
            => new ContactDto
            {
                Address = contact.Address,
                Name = contact.Name
            };
    }
}
