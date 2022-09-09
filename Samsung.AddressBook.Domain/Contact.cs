using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Samsung.AddressBook.Domain;

public class Contact
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public bool IsFavorite { get; set; }
    
    public IEnumerable<Phone>? Phones { get; set; }
    public IEnumerable<Address>? Addresses { get; set; }
}