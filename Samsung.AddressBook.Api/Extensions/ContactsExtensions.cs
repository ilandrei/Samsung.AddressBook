using Samsung.AddressBook.Api.ApiModels;
using Samsung.AddressBook.Api.Requests;
using Samsung.AddressBook.Application.Interops.ServiceModels;

namespace Samsung.AddressBook.Api.Extensions;

public static class ContactsExtensions
{
    public static ContactApiModel FromDomain(this ContactServiceModel domain)
    {
        return new ContactApiModel(domain.Id,domain.Name,domain.IsFavorite
            ,domain.Phones?.Select(p => p.FromDomain())
            ,domain.Addresses?.Select(a => a.FromDomain()));
    }

    public static AddContactRequestServiceModel ToDomain(this AddContactRequest request)
    {
        return new AddContactRequestServiceModel(request.Name, request.IsFavorite!.Value
            , request.Address?.ToDomain()
            , request.Phone?.ToDomain());
    }
}