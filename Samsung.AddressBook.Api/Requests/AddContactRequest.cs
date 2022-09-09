using Samsung.AddressBook.Api.ApiModels;

namespace Samsung.AddressBook.Api.Requests;

public class AddContactRequest
{
    public string? Name { get; set; }
    public bool? IsFavorite { get; set; }
    public ContactAddressApiModel? Address { get; set; }
    public ContactPhoneApiModel? Phone { get; set; }
}