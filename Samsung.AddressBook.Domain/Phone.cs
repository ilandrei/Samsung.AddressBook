using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Samsung.AddressBook.Common;

namespace Samsung.AddressBook.Domain;

public class Phone
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public PhoneType Type { get; set; }

    [Required] 
    public string Value { get; set; } = null;
    
    [Required]
    public int ContactId { get; set; }
    [Required] 
    public Contact Contact { get; set; } = null!;
}