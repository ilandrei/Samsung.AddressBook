using Samsung.AddressBook.Common;

namespace Samsung.AddressBook.Application.Interops.ServiceModels;

public class ContactAddressServiceModel
{
    public ContactAddressServiceModel(int id, AddressType type, string value)
    {
        Id = id;
        Type = type;
        Value = value;
    }

    public int Id { get; set; }
    public AddressType Type { get; set; }
    public string Value { get; set; } 
  
}