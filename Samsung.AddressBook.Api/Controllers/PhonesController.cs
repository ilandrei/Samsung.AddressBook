using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Samsung.AddressBook.Api.Requests;
using Samsung.AddressBook.Application.Interops;
using Samsung.AddressBook.Common.FunctionalExtensions;

namespace Samsung.AddressBook.Api.Controllers;

[ApiController]
[Route("/api/v1/phones")]
public class PhonesController:ControllerBase
{
    private readonly IPhonesService _phonesService;
    public PhonesController(IPhonesService phonesService)
    {
        _phonesService = phonesService;
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var domainResponse = await _phonesService.DeletePhone(id);
        
        return domainResponse.ToHttpResponse();
    }
    
    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] UpdatePhoneRequest request)
    {
        var domainResponse = await _phonesService.UpdatePhone(request.Id, request.Type,request.Value);
        
        return domainResponse.ToHttpResponse();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddPhoneRequest request)
    {
        if (request.Type == null || request.Value == null)
        {
            return BadRequest();
        }
        
        var domainResponse = await _phonesService.CreatePhone(request.ContactId, request.Type.Value,request.Value);

        return domainResponse.ToHttpResponse();
    }
}