using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DemoFluentValidation.Controllers;

[ApiController]
[Route("person")]
public class PersonController : ControllerBase
{
    private IValidator<Person> _validator;

    public PersonController(IValidator<Person> validator) =>
        _validator = validator;

    [HttpPost(Name = "PostPerson")]
    public IActionResult Post(Person person)
    {
        var validationResult =  person.Validate(_validator);

        if(validationResult.isValid is false)
            return BadRequest(validationResult.Errors);

        return Ok();
    }
}
