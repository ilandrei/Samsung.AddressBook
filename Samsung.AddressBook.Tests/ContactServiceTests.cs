using System.Net;
using CSharpFunctionalExtensions;
using FakeItEasy;
using FluentAssertions;
using Samsung.AddressBook.Application;
using Samsung.AddressBook.Application.Interops.ServiceModels;
using Samsung.AddressBook.Common;
using Samsung.AddressBook.Common.FunctionalExtensions;
using Samsung.AddressBook.DataAccess.Interops.Repositories;

namespace Samsung.AddressBook.Tests;

public class ContactServiceTests
{
    [Fact]
    public async Task AddContact_Valid_Model_ShouldReturn_Success()
    {
        var contactRepository = A.Fake<IContactsRepository>();
        var phoneRepository = A.Fake<IPhonesRepository>();
        var addressesRepository = A.Fake<IAddressesRepository>();

        var address = new ContactAddressServiceModel(0, AddressType.Home, "testAddress");
        var phone = new ContactPhoneServiceModel(0, PhoneType.Home, "testPhone");
        var request = new AddContactRequestServiceModel("testContact", true, address, phone);
        
        A.CallTo(() => contactRepository.AddContact(null!)).WithAnyArguments().Returns(Task.FromResult(Result.Success<int, Error>(1)));
        A.CallTo(() => phoneRepository.Create(0,PhoneType.Home,null!)).WithAnyArguments().Returns(Task.FromResult(UnitResult.Success<Error>()));
        A.CallTo(() => addressesRepository.Create(0,AddressType.Home,null!)).WithAnyArguments().Returns(Task.FromResult(UnitResult.Success<Error>()));

        var contactService = new ContactsService(contactRepository,addressesRepository,phoneRepository);

        var response = await contactService.AddContact(request);
        response.IsSuccess.Should().Be(true);
    }

    [Fact]
    public async Task AddContact_ContactFail_ShouldReturn_Error()
    {
        var contactRepository = A.Fake<IContactsRepository>();
        var phoneRepository = A.Fake<IPhonesRepository>();
        var addressesRepository = A.Fake<IAddressesRepository>();

        var address = new ContactAddressServiceModel(0, AddressType.Home, "testAddress");
        var phone = new ContactPhoneServiceModel(0, PhoneType.Home, "testPhone");
        var request = new AddContactRequestServiceModel("testContact", true, address, phone);
        
        A.CallTo(() => contactRepository.AddContact(null!)).WithAnyArguments().Returns(Task.FromResult(Result.Failure<int, Error>(new Error(HttpStatusCode.BadRequest,"Failed"))));
        A.CallTo(() => phoneRepository.Create(0,PhoneType.Home,null!)).WithAnyArguments().Returns(Task.FromResult(UnitResult.Success<Error>()));
        A.CallTo(() => addressesRepository.Create(0,AddressType.Home,null!)).WithAnyArguments().Returns(Task.FromResult(UnitResult.Success<Error>()));

        var contactService = new ContactsService(contactRepository,addressesRepository,phoneRepository);

        var response = await contactService.AddContact(request);
        response.IsSuccess.Should().Be(false);
    }
}