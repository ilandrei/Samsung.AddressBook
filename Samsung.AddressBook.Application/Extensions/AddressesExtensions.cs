using Samsung.AddressBook.Application.Interops.ServiceModels;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.Application.Extensions;

public static class AddressesExtensions
{
      public static ContactAddressServiceModel FromDomain(this Address domain)
      {
            return new ContactAddressServiceModel(domain.Id, domain.Type, domain.Value);
      }
}