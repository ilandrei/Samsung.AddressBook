using System.Net;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Samsung.AddressBook.Common.FunctionalExtensions;
using Samsung.AddressBook.Common.LinqExtensions;
using Samsung.AddressBook.DataAccess.Interops;
using Samsung.AddressBook.DataAccess.Interops.Repositories;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.DataAccess.Repositories;

public class ContactsRepository:IContactsRepository
{
    private readonly IDataContext _context;

    public ContactsRepository(IDataContext context)
    {
        _context = context;
    }

    public async Task<Result<IEnumerable<Contact>, Error>> GetAll(bool? favorites,string? search)
    {
        return await _context.Contacts
            .WhereIfNotNull(favorites, c => c.IsFavorite == favorites)
            .WhereIfNotNull(search,c => c.Name.ToLower().Contains(search!.ToLower()))
            .Include(c => c.Addresses)
            .Include(c => c.Phones)
            .ToListAsync();
    }

    public async Task<Result<Contact, Error>> GetById(int id)
    {
        var contact = await _context.Contacts
            .Include(c => c.Phones)
            .Include(c =>c.Addresses).FirstOrDefaultAsync(c => c.Id == id);
        return contact ?? 
               Result.Failure<Contact, Error>(new Error(HttpStatusCode.NotFound,"Contact not found"));
    }

    public async Task<Result<int, Error>> AddContact(Contact contact)
    {
        try
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync(CancellationToken.None);
            return contact.Id;
        }
        catch (Exception)
        {
            return Result.Failure<int,Error>(new Error(HttpStatusCode.InternalServerError,"Error while deleting from the database")); 
        }
    }

    public async Task<UnitResult<Error>> Delete(int id)
    {
        var item = await _context.Contacts.FirstOrDefaultAsync(i => i.Id == id);
        if (item == null)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.NotFound,"Item not found"));
        }

        try
        {
            _context.Contacts.Remove(item);
            await _context.SaveChangesAsync(CancellationToken.None);
            return UnitResult.Success<Error>();
        }
        catch (Exception)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.InternalServerError,"Error while deleting from the database"));
        }
    }

    public async Task<UnitResult<Error>> Update(int id,string? requestName, bool? requestIsFavorite)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(a => a.Id == id);
        if (contact == null)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.NotFound,"Contact was not found"));
        }

        contact.Name = requestName ?? contact.Name;
        contact.IsFavorite = requestIsFavorite ?? contact.IsFavorite;

        try
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync(CancellationToken.None);
            return UnitResult.Success<Error>();
        }
        catch (Exception)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.InternalServerError,"Error updating contact"));
        }
    }
}