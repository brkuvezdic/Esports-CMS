using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Colleges;
using FluentValidation;

namespace EsportsCmsApplication.DTOValidations
{
    public class CreateCollegeValidator: AbstractValidator<CreateCollegeDto>
    {
        private readonly ICollegeRepository collegeRepository;

        public CreateCollegeValidator(ICollegeRepository collegeRepository)
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().MaximumLength(50).MustAsync(async (title, cancellation) => !await collegeRepository.CollegeExistsAsync(title)).WithMessage("The College title must be unique");
            RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(500);
            this.collegeRepository = collegeRepository;
        }

    }
}
