using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Samsung.AddressBook.Api.Requests;
using Samsung.AddressBook.Application.Interops;
using Samsung.AddressBook.Common.FunctionalExtensions;

namespace Samsung.AddressBook.Api.Controllers;


[ApiController]
[Route("/api/v1/addresses")]
public class AddressesController:ControllerBase
{
    private readonly IAddressesService _addressesService;

    public AddressesController(IAddressesService addressesService)
    {
        _addressesService = addressesService;
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var domainResponse = await _addressesService.DeleteAddress(id);
        
        return domainResponse.ToHttpResponse();
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] UpdateAddressRequest request)
    {
        var domainResponse = await _addressesService.UpdateAddress(request.Id, request.Type,request.Value);
        
        return domainResponse.ToHttpResponse();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddAddressRequest request)
    {
        if (request.Type == null || request.Value == null)
        {
            return BadRequest();
        }
        
        var domainResponse = await _addressesService.CreateAddress(request.ContactId, request.Type.Value,request.Value);
        
        return domainResponse.ToHttpResponse();
    }

}