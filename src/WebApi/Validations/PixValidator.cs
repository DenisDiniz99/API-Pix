using FluentValidation;
using WebApi.Models;

namespace WebApi.Validations
{
    public class PixValidator : AbstractValidator<StaticPix>
    {
        public PixValidator()
        {
            RuleFor(x => x.MerchantName)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome do recebedor deve ser informado")
                .MaximumLength(25)
                .WithMessage("O nome do recebedor deve conter até 25 caracteres");
            RuleFor(x => x.MerchantCity)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome da cidade de transação deve ser informada")
                .MaximumLength(25)
                .WithMessage("O nome da cidade de transação deve conter até 25 caracteres");
            RuleFor(x => x.Key)
                .NotNull()
                .NotEmpty()
                .WithMessage("A chave Pix deve ser informada");
            RuleFor(x => x.Total)
                .GreaterThan(0)
                .WithMessage("O valor deve ser maior que 0");
        }
    }
}