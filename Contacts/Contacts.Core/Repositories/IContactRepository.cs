using Contacts.Core.Entities;
using System.Threading.Tasks;

namespace Contacts.Core.Repositories
{
    public interface IContactRepository
    {
        Task AddAsync(Contact contact);
    }
}
