using Contacts.Application.DTOs;
using Contacts.Core.Entities;
using Contacts.Core.Repositories;
using System.Threading.Tasks;

namespace Contacts.Application.UseCases
{
    public class CreateContactUseCase
    {
        private readonly IContactRepository _contactRepository;

        public CreateContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Execute(ContactDto contactDto)
        {
            await _contactRepository.AddAsync(new Contact
            {
                Name = contactDto.Name,
                Address = contactDto.Address
            });
        }
    }
}
