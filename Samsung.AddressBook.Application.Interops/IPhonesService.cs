using CSharpFunctionalExtensions;
using Samsung.AddressBook.Common;
using Samsung.AddressBook.Common.FunctionalExtensions;

namespace Samsung.AddressBook.Application.Interops;

public interface IPhonesService
{
    Task<UnitResult<Error>> DeletePhone(int id);
    Task<UnitResult<Error>> UpdatePhone(int id, PhoneType? requestType, string? requestValue);
    Task<UnitResult<Error>> CreatePhone(int contactId, PhoneType requestType, string requestValue);
}