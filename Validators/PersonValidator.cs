using FluentValidation;

namespace DemoFluentValidation;

public class PersonValidator: AbstractValidator<Person> 
{
    public PersonValidator()
    {
        RuleFor(x => x.Name).Length(0, 100)
            .WithMessage("O Nome é obrigatório");
        RuleFor(x => x.Email).EmailAddress()
            .WithMessage("Endereço de e-mail inválido");
        RuleFor(x => x.Age).InclusiveBetween(18, 60)
            .WithMessage("Deve ter entre 18 e 60 anos");
        RuleFor(x => x.Document).Length(11)
            .WithMessage("CPF inválido, deve ter 11 digitos.");
    }
}
