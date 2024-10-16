using Contacts.Core.Entities;
using Contacts.Core.Repositories;
using Raven.Client.Documents;
using System.Threading.Tasks;

namespace Contacts.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDocumentStore _store;

        public ContactRepository(IDocumentStore store)
        {
            _store = store;
        }

        public async Task AddAsync(Contact contact)
        {
            using (var session = _store.OpenAsyncSession())
            {
                await session.StoreAsync(contact);
                await session.SaveChangesAsync();
            }
        }

    }
}
