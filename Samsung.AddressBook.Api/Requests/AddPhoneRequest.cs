using Samsung.AddressBook.Common;

namespace Samsung.AddressBook.Api.Requests;

public class AddPhoneRequest
{
    public int ContactId { get; set; }
    public PhoneType? Type { get; set; }
    public string? Value { get; set; }
}