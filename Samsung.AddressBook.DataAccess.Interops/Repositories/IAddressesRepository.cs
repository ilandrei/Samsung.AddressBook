using CSharpFunctionalExtensions;
using Samsung.AddressBook.Common;
using Samsung.AddressBook.Common.FunctionalExtensions;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.DataAccess.Interops.Repositories;

public interface IAddressesRepository
{
    Task<UnitResult<Error>> Delete(int id);
    Task<UnitResult<Error>> Update(int id, AddressType? requestType, string? requestValue);
    Task<UnitResult<Error>> Create(int contactId, AddressType requestType, string requestValue);
}