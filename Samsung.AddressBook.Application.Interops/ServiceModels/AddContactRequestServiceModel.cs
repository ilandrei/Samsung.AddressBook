namespace Samsung.AddressBook.Application.Interops.ServiceModels;

public class AddContactRequestServiceModel
{
    public AddContactRequestServiceModel(string? name, bool isFavorite, ContactAddressServiceModel? address, ContactPhoneServiceModel? phones)
    {
        Name = name;
        IsFavorite = isFavorite;
        Address = address;
        Phone = phones;
    }

    public string? Name { get; set; }
    public bool IsFavorite { get; set; }
    public ContactAddressServiceModel? Address { get; set; }
    public ContactPhoneServiceModel? Phone { get; set; }
}