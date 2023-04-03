using DoctorWho.web.DTOs;
using FluentValidation;
namespace DoctorWho.web.Validators
{
    public class DoctorForUpsertValidator :AbstractValidator<DoctorForUpsertDto>
    {
        public DoctorForUpsertValidator()
        {
            RuleFor(d => d.Name).NotNull()
                .WithMessage("Doctor'same should bo provided");
            RuleFor(d => d.Number).NotNull()
                .WithMessage("Doctor's Number should be provided");
            RuleFor(d => d.LastEpisodeDate)
               .Null()
                .When(d => d.FirstEpisodeDate == null)
                .WithMessage("Last episode date must has no value when first episode date has no value");

            RuleFor(d => d.LastEpisodeDate)
                .GreaterThanOrEqualTo(d => d.FirstEpisodeDate)
                .WithMessage("Last Episode date must be greater than or equal to the first episode date");
        }
    }
}
