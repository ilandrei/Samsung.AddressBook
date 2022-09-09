using CSharpFunctionalExtensions;
using Samsung.AddressBook.Application.Interops;
using Samsung.AddressBook.Application.Interops.ServiceModels;
using Samsung.AddressBook.Common.FunctionalExtensions;
using Samsung.AddressBook.DataAccess.Interops.Repositories;
using Samsung.AddressBook.Application.Extensions;
using Samsung.AddressBook.Domain;

namespace Samsung.AddressBook.Application;

public class ContactsService:IContactsService
{
    private readonly IContactsRepository _contactsRepository;
    private readonly IAddressesRepository _addressesRepository;
    private readonly IPhonesRepository _phonesRepository;

    public ContactsService(IContactsRepository contactsRepository,IAddressesRepository addressesRepository,IPhonesRepository phonesRepository)
    {
        _contactsRepository = contactsRepository;
        _addressesRepository = addressesRepository;
        _phonesRepository = phonesRepository;
    }

    public async Task<Result<IEnumerable<ContactServiceModel>, Error>> GetAll(bool? favorites,string? search)
    {
        var response =  await _contactsRepository.GetAll(favorites,search);
        return response.IsFailure ? 
            Result.Failure<IEnumerable<ContactServiceModel>,Error>(response.Error) : 
            Result.Success<IEnumerable<ContactServiceModel>,Error>(response.Value.Select(c => c.FromDomain()));
    }

    public async Task<Result<ContactServiceModel, Error>> GetById(int id)
    {
        var response =  await _contactsRepository.GetById(id);
        return response.IsFailure ? 
            Result.Failure<ContactServiceModel,Error>(response.Error) : 
            Result.Success<ContactServiceModel,Error>(response.Value.FromDomain());
    }

    public async Task<UnitResult<Error>> AddContact(AddContactRequestServiceModel request)
    {
        var contact = new Contact
        {
            Name = request.Name!,
            IsFavorite = request.IsFavorite,
            Addresses = Array.Empty<Address>(),
            Phones = Array.Empty<Phone>()
        };
        var saveContactResult = await _contactsRepository.AddContact(contact);
        if (saveContactResult.IsFailure)
        {
            return saveContactResult;
        }

        if (request.Phone != null)
        {
          
            var savePhonesResult =await _phonesRepository.Create(saveContactResult.Value,request.Phone.Type,request.Phone.Value);
            if (savePhonesResult.IsFailure)
            {
                return savePhonesResult;
            }
        }
        
        if (request.Address != null)
        {
            var saveAddressesResult =await _addressesRepository.Create(saveContactResult.Value,request.Address.Type,request.Address.Value);
            if (saveAddressesResult.IsFailure)
            {
                return saveAddressesResult;
            }
        }

        return UnitResult.Success<Error>();
    }

    public async Task<UnitResult<Error>> DeleteContact(int id)
    {
        return await _contactsRepository.Delete(id);
    }

    public async Task<UnitResult<Error>> UpdateContact(int id,string? requestName, bool? requestIsFavorite)
    {
        return await _contactsRepository.Update(id, requestName, requestIsFavorite);
    }
}