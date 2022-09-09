using Microsoft.AspNetCore.Mvc;
using Samsung.AddressBook.Api.Extensions;
using Samsung.AddressBook.Api.Requests;
using Samsung.AddressBook.Application.Interops;
using Samsung.AddressBook.Common.FunctionalExtensions;

namespace Samsung.AddressBook.Api.Controllers;

[ApiController]
[Route("/api/v1/contacts")]
public class ContactsController:ControllerBase
{
    private readonly IContactsService _contactsService;
    public ContactsController(IContactsService contactsService)
    {
        _contactsService = contactsService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] bool? favorites,[FromQuery] string? search)
    {
        var domainResponse = await _contactsService.GetAll(favorites,search);
        
        return domainResponse.IsFailure
            ? domainResponse.Error.ToHttpResponse()
            : Ok(domainResponse.Value.Select(c => c.FromDomain()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var domainResponse = await _contactsService.GetById(id);
        return domainResponse.IsFailure
            ? domainResponse.Error.ToHttpResponse()
            : Ok(domainResponse.Value.FromDomain());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddContactRequest request)
    {
        if (request.Name == null || request.IsFavorite == null)
        {
            return BadRequest();
        }
        var domainResponse = await _contactsService.AddContact(request.ToDomain());
        
        return domainResponse.ToHttpResponse();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var domainResponse = await _contactsService.DeleteContact(id);
        
        return domainResponse.ToHttpResponse();
    }
    
    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] UpdateContactRequest request)
    {
        var domainResponse = await _contactsService.UpdateContact(request.Id, request.Name,request.IsFavorite);
        
        return domainResponse.ToHttpResponse();
    }
}