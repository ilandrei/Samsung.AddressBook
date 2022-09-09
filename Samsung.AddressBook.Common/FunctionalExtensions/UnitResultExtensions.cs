using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Samsung.AddressBook.Common.FunctionalExtensions;

public static class UnitResultExtensions
{
    public static IActionResult ToHttpResponse(this UnitResult<Error> unitResult)
    {
        if (unitResult.IsSuccess) return new OkResult();
        return new ObjectResult(unitResult.Error.Message)
        {
            StatusCode = (int)unitResult.Error.HttpStatusCode
        };
    }

    public static ObjectResult ToHttpResponse(this Error error)
    {
        return new ObjectResult(error.Message)
        {
            StatusCode = (int)error.HttpStatusCode
        };
    }
}
