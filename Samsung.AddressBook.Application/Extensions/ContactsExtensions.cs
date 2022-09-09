using Samsung.AddressBook.Application.Interops.ServiceModels;
using Samsung.AddressBook.Domain;
using Samsung.AddressBook.Application.Extensions;

namespace Samsung.AddressBook.Application.Extensions;

public static class ContactsExtensions
{
    public static ContactServiceModel FromDomain(this Contact domain)
    {
        return new ContactServiceModel(domain.Id,domain.Name,domain.IsFavorite
            ,domain.Phones?.Select(p => p.FromDomain())
            ,domain.Addresses?.Select(a => a.FromDomain()));
    }
}