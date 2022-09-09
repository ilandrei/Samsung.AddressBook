using CSharpFunctionalExtensions;
using Samsung.AddressBook.Application.Interops.ServiceModels;
using Samsung.AddressBook.Common.FunctionalExtensions;

namespace Samsung.AddressBook.Application.Interops;

public interface IContactsService
{
    Task<Result<IEnumerable<ContactServiceModel>,Error>> GetAll(bool? favorites,string? search);
    Task<Result<ContactServiceModel,Error>> GetById(int id);
    Task<UnitResult<Error>> AddContact(AddContactRequestServiceModel toDomain);
    Task<UnitResult<Error>> DeleteContact(int id);
    Task<UnitResult<Error>> UpdateContact(int id, string? requestName, bool? requestIsFavorite);
}