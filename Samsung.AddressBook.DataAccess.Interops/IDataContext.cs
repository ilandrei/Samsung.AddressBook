using Microsoft.EntityFrameworkCore;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.DataAccess.Interops;

public interface IDataContext
{
    DbSet<Contact> Contacts { get; set; }
    DbSet<Phone> Phones { get; set; }
    DbSet<Address> Addresses { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}