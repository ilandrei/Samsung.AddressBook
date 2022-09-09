using System.Net;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Samsung.AddressBook.Common;
using Samsung.AddressBook.Common.FunctionalExtensions;
using Samsung.AddressBook.DataAccess.Interops;
using Samsung.AddressBook.DataAccess.Interops.Repositories;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.DataAccess.Repositories;

public class PhonesRepository:IPhonesRepository
{
    private readonly IDataContext _context;

    public PhonesRepository(IDataContext context)
    {
        _context = context;
    }
    
    public async Task<UnitResult<Error>> Delete(int id)
    {
        var item = await _context.Phones.FirstOrDefaultAsync(i => i.Id == id);
        if (item == null)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.NotFound,"Item not found"));
        }

        try
        {
            _context.Phones.Remove(item);
            await _context.SaveChangesAsync(CancellationToken.None);
            return UnitResult.Success<Error>();
        }
        catch (Exception)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.InternalServerError,"Error while deleting from the database"));
        }
    }

    public async Task<UnitResult<Error>> Update(int id,PhoneType? requestType, string? requestValue)
    {
        var phone = await _context.Phones.FirstOrDefaultAsync(a => a.Id == id);
        if (phone == null)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.NotFound,"Phone was not found"));
        }

        phone.Type = requestType ?? phone.Type;
        phone.Value = requestValue ?? phone.Value;

        try
        {
            _context.Phones.Update(phone);
            await _context.SaveChangesAsync(CancellationToken.None);
            return UnitResult.Success<Error>();
        }
        catch (Exception)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.InternalServerError, "Error updating phone"));
        }
    }

    public async Task<UnitResult<Error>> Create(int contactId, PhoneType requestType, string requestValue)
    {
        var phone = new Phone
        {
            ContactId = contactId,
            Type = requestType,
            Value = requestValue
        };
        try
        {
            await _context.Phones.AddAsync(phone);
            await _context.SaveChangesAsync(CancellationToken.None);
            return UnitResult.Success<Error>();
        }
        catch (Exception)
        {
            return UnitResult.Failure(new Error(HttpStatusCode.InternalServerError,"Error while saving phone"));
        }
    }
    
}