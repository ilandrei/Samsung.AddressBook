using Samsung.AddressBook.Common;

namespace Samsung.AddressBook.Api.Requests;

public class AddAddressRequest
{
    public int ContactId { get; set; }
    public AddressType? Type { get; set; }
    public string? Value { get; set; }
}