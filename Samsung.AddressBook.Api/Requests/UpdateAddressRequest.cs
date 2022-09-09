using Samsung.AddressBook.Common;

namespace Samsung.AddressBook.Api.Requests;

public class UpdateAddressRequest
{
    public int Id { get; set; }
    public AddressType? Type { get; set; }
    public string? Value { get; set; }
}