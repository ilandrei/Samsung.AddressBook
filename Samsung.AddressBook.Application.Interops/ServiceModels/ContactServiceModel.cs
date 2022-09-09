

namespace Samsung.AddressBook.Application.Interops.ServiceModels;

public class ContactServiceModel
{
    public ContactServiceModel(int id, string name, bool isFavorite, IEnumerable<ContactPhoneServiceModel>? phones, IEnumerable<ContactAddressServiceModel>? addresses)
    {
        Id = id;
        Name = name;
        IsFavorite = isFavorite;
        Phones = phones;
        Addresses = addresses;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsFavorite { get; set; }
    public IEnumerable<ContactPhoneServiceModel>? Phones { get; set; }
    public IEnumerable<ContactAddressServiceModel>? Addresses { get; set; }
}
