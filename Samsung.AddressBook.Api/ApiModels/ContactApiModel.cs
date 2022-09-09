namespace Samsung.AddressBook.Api.ApiModels;

public class ContactApiModel
{
    public ContactApiModel(int id, string name, bool isFavorite, IEnumerable<ContactPhoneApiModel>? phones, IEnumerable<ContactAddressApiModel>? addresses)
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
    public IEnumerable<ContactPhoneApiModel>? Phones { get; set; }
    public IEnumerable<ContactAddressApiModel>? Addresses { get; set; }
}
