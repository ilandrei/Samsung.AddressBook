using CSharpFunctionalExtensions;
using Samsung.AddressBook.Common;
using Samsung.AddressBook.Common.FunctionalExtensions;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.DataAccess.Interops.Repositories;

public interface IPhonesRepository
{
    Task<UnitResult<Error>> Delete(int id);
    Task<UnitResult<Error>> Update(int id,PhoneType? requestType, string? requestValue);
    Task<UnitResult<Error>> Create(int contactId, PhoneType requestType, string requestValue);
}