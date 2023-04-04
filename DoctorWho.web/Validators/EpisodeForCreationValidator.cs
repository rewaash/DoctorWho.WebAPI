using DoctorWho.web.DTOs;
using FluentValidation;

namespace DoctorWho.web.Validators
{
    public class EpisodeForCreationValidator :AbstractValidator<EpisodeForCreationDto>
    {
        public EpisodeForCreationValidator()
        {
            RuleFor(e => e.AuthorId).NotNull();
            RuleFor(e => e.DoctorId).NotNull();
            RuleFor(e => e.SeriesNumber)
                .NotNull()
                .Length(10);
        }
    }
}
