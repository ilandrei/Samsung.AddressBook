using Samsung.AddressBook.Api.ApiModels;
using Samsung.AddressBook.Application.Interops.ServiceModels;

namespace Samsung.AddressBook.Api.Extensions;

public static class PhonesExtensions
{
    public static ContactPhoneApiModel FromDomain(this ContactPhoneServiceModel domain)
    {
        return new ContactPhoneApiModel(domain.Id, domain.Type, domain.Value);
    }
    
    public static ContactPhoneServiceModel ToDomain(this ContactPhoneApiModel domain)
    {
        return new ContactPhoneServiceModel(domain.Id, domain.Type, domain.Value);
    }
}