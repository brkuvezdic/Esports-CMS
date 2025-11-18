using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Colleges;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.DTOValidations
{
    public class UpdateCollegeValidator: AbstractValidator<UpdateCollegeDto>
    {
        private readonly ICollegeRepository collegeRepository;

        public UpdateCollegeValidator(ICollegeRepository collegeRepository)
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().MaximumLength(50).MustAsync(async (title, cancellation) => title == null || !await collegeRepository.CollegeExistsAsync(title)).WithMessage("The College title must be unique");
            RuleFor(x => x.Description).MaximumLength(500);
            this.collegeRepository = collegeRepository;
        }

    }
}



