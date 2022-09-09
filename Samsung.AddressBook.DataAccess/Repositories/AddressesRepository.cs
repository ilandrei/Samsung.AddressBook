using System.Net;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Samsung.AddressBook.Common;
using Samsung.AddressBook.Common.FunctionalExtensions;
using Samsung.AddressBook.DataAccess.Interops;
using Samsung.AddressBook.DataAccess.Interops.Repositories;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.DataAccess.Repositories;

public class AddressesRepository:IAddressesRepository
{
    private readonly IDataContext _context;

    public AddressesRepository(IDataContext context)
    {
        _context = context;
    }

   

    public async Task<UnitResult<Error>> Delete(int id)
    {
        var item = await _context.Addresses.FirstOrDefaultAsync(i => i.Id == id);
        if (item == null)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.NotFound,"Item not found"));
        }

        try
        {
            _context.Addresses.Remove(item);
            await _context.SaveChangesAsync(CancellationToken.None);
            return UnitResult.Success<Error>();
        }
        catch (Exception)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.InternalServerError,"Error while deleting from the database"));
        }
    }

    public async Task<UnitResult<Error>> Update(int id,AddressType? requestType, string? requestValue)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        if (address == null)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.NotFound,"Address was not found"));
        }

        address.Type = requestType ?? address.Type;
        address.Value = requestValue ?? address.Value;

        try
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync(CancellationToken.None);
            return UnitResult.Success<Error>();
        }
        catch (Exception)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.InternalServerError,"Error updating address"));
        }
    }

    public async Task<UnitResult<Error>> Create(int contactId, AddressType requestType, string requestValue)
    {
        var address = new Address
        {
            ContactId = contactId,
            Type = requestType,
            Value = requestValue
        };
        try
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync(CancellationToken.None);
            return UnitResult.Success<Error>();
        }
        catch (Exception)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.InternalServerError,"Error while saving address"));
        }
    }
}