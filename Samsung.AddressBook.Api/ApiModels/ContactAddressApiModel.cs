using Samsung.AddressBook.Common;

namespace Samsung.AddressBook.Api.ApiModels;

public class ContactAddressApiModel
{
    public ContactAddressApiModel(int id, AddressType type, string value)
    {
        Id = id;
        Type = type;
        Value = value;
    }

    public int Id { get; set; }
    
    public AddressType Type { get; set; }

    public string Value { get; set; }
}