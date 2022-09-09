using Samsung.AddressBook.Application.Interops.ServiceModels;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.Application.Extensions;

public static class PhonesExtensions
{
    public static ContactPhoneServiceModel FromDomain(this Phone domain)
    {
        return new ContactPhoneServiceModel(domain.Id, domain.Type, domain.Value);
    }
}