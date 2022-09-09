using CSharpFunctionalExtensions;
using Samsung.AddressBook.Application.Interops;
using Samsung.AddressBook.Common;
using Samsung.AddressBook.Common.FunctionalExtensions;
using Samsung.AddressBook.DataAccess.Interops.Repositories;

namespace Samsung.AddressBook.Application;

public class PhonesService:IPhonesService
{
    private readonly IPhonesRepository _phonesRepository;

    public PhonesService(IPhonesRepository phonesRepository)
    {
        _phonesRepository = phonesRepository;
    }

    public async Task<UnitResult<Error>> DeletePhone(int id)
    {
        return await _phonesRepository.Delete(id);
    }

    public async Task<UnitResult<Error>> UpdatePhone(int id,PhoneType? requestType, string? requestValue)
    {
        return await _phonesRepository.Update(id, requestType, requestValue);
    }

    public async Task<UnitResult<Error>> CreatePhone(int contactId, PhoneType requestType, string requestValue)
    {
        return await _phonesRepository.Create(contactId, requestType, requestValue);
    }
}