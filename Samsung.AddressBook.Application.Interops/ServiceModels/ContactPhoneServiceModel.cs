using Samsung.AddressBook.Common;

namespace Samsung.AddressBook.Application.Interops.ServiceModels;

public class ContactPhoneServiceModel
{
    public ContactPhoneServiceModel(int id, PhoneType type, string value)
    {
        Id = id;
        Type = type;
        Value = value;
    }

    public int Id { get; set; }
    
    public PhoneType Type { get; set; }

    public string Value { get; set; }
    
}