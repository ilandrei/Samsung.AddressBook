using Microsoft.EntityFrameworkCore;
using Samsung.AddressBook.DataAccess.Interops;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.DataAccess;

public class DataContext:DbContext,IDataContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    
    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<Phone> Phones { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    
}