using FluentValidation;

namespace DemoFluentValidation;

public record Person 
{
    public string Name { get; set; } = string.Empty!;
    public string Document{ get; set; } = string.Empty!;
    public string Email { get; set; } = string.Empty!;
    public int Age { get; set; }

    public (bool isValid, IEnumerable<string> Errors) Validate(IValidator<Person> validator) 
    {
        var validationResult = validator.Validate(this);
        return (validationResult.IsValid, validationResult.Errors.Select(_ => _.ErrorMessage));
    }
}