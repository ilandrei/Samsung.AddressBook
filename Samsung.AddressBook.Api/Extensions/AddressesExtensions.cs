using Samsung.AddressBook.Api.ApiModels;
using Samsung.AddressBook.Application.Interops.ServiceModels;

namespace Samsung.AddressBook.Api.Extensions;

public static class AddressesExtensions
{
    public static ContactAddressApiModel FromDomain(this ContactAddressServiceModel domain)
    {
        return new ContactAddressApiModel(domain.Id, domain.Type, domain.Value);
    }
    
    public static ContactAddressServiceModel ToDomain(this ContactAddressApiModel domain)
    {
        return new ContactAddressServiceModel(domain.Id, domain.Type, domain.Value);
    }
}