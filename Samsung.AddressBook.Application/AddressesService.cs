using CSharpFunctionalExtensions;
using Samsung.AddressBook.Application.Interops;
using Samsung.AddressBook.Common;
using Samsung.AddressBook.Common.FunctionalExtensions;
using Samsung.AddressBook.DataAccess.Interops.Repositories;

namespace Samsung.AddressBook.Application;

public class AddressesService:IAddressesService
{
    private readonly IAddressesRepository _addressesRepository;

    public AddressesService(IAddressesRepository repository)
    {
        _addressesRepository = repository;
    }

    public async Task<UnitResult<Error>> DeleteAddress(int id)
    {
        return await _addressesRepository.Delete(id);
    }

    public async Task<UnitResult<Error>> UpdateAddress(int id,AddressType? requestType, string? requestValue)
    {
        return await _addressesRepository.Update(id, requestType, requestValue);
    }

    public async Task<UnitResult<Error>> CreateAddress(int contactId, AddressType requestType, string requestValue)
    {
        return await _addressesRepository.Create(contactId, requestType, requestValue);
    }
}