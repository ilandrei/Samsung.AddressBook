using Samsung.AddressBook.Common;

namespace Samsung.AddressBook.Api.Requests;

public class UpdatePhoneRequest
{
    public int Id { get; set; }
    public PhoneType? Type { get; set; }
    public string? Value { get; set; }
}