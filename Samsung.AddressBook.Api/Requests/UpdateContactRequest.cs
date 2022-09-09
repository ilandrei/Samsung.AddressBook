namespace Samsung.AddressBook.Api.Requests;

public class UpdateContactRequest
{
    public int Id { get; set; }
    public bool? IsFavorite { get; set; }
    public string? Name { get; set; }
}