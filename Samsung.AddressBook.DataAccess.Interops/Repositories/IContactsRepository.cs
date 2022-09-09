using CSharpFunctionalExtensions;
using Samsung.AddressBook.Common.FunctionalExtensions;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.DataAccess.Interops.Repositories;

public interface IContactsRepository
{
    Task<Result<IEnumerable<Contact>,Error>> GetAll(bool? favorites,string? search);
    Task<Result<Contact,Error>> GetById(int id);
    Task<Result<int, Error>> AddContact(Contact contact);
    Task<UnitResult<Error>> Delete(int id);
    Task<UnitResult<Error>> Update(int id,string? requestName, bool? requestIsFavorite);
}