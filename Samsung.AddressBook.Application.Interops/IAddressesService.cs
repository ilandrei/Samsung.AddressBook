using CSharpFunctionalExtensions;
using Samsung.AddressBook.Common;
using Samsung.AddressBook.Common.FunctionalExtensions;

namespace Samsung.AddressBook.Application.Interops;

public interface IAddressesService
{
    Task<UnitResult<Error>> DeleteAddress(int id);
    Task<UnitResult<Error>> UpdateAddress(int id, AddressType? requestType, string? requestValue);
    Task<UnitResult<Error>> CreateAddress(int contactId, AddressType requestType, string requestValue);
}