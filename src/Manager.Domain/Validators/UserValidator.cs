using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(userClass => userClass)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(userClass => userClass.Name)
                .NotEmpty()
                .WithMessage("O Nome não pode ser vazio")

                .NotNull()
                .WithMessage("O nome não pode ser nulo")

                .MinimumLength(2)
                .WithMessage("O Tamanho mínimo do nome deve ser 2 caracteres")

                .MaximumLength(80)
                .WithMessage("O Tamanho maximo do nome deve ser 80 caracteres");

            RuleFor(userClass => userClass.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia")

                .NotNull()
                .WithMessage("A senha não pode ser nula")

                .MinimumLength(6)
                .WithMessage("O Tamanho mínimo são de 6 caracteres")

                .MaximumLength(12)
                .WithMessage("O Tamanho máximo são de 12 caracteres");

            RuleFor(userClass => userClass.Email)
                .NotEmpty()
                .WithMessage("O Email não pode ser vazio")

                .NotNull()
                .WithMessage("O Email não pode ser nulo")

                .MinimumLength(5)
                .WithMessage("Limite do tamanho minimo do email 5")

                .MaximumLength(180)
                .WithMessage("Limite do tamanho máximo do email 180")

                .Matches(@"/^([a-z]){1,}([a-z0-9._-]){1,}([@]){1}([a-z]){2,}([.]){1}([a-z]){2,}([.]?){1}([a-z]?){2,}$/i")
                .WithMessage("Email no formato inválido");

             

        }

    }
}
