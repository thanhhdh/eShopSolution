using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required!")
                .MaximumLength(50).WithMessage("First name is over than 50 charactors");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required!")
                .MaximumLength(50).WithMessage("Last name is over than 50 charactors");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required!")
               .Length(5, 50).WithMessage("User name is minimum 5 charactors and maximum 50 charactors");
            RuleFor(x => x.Dob).GreaterThan(DateTime.MinValue);
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Not an email");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!")
                .MinimumLength(6).WithMessage("Password is at least 6 charactors");
            RuleFor(x => x).Custom((request, context) => 
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("ConfirmPassword not match!");
                }
            }).NotEmpty().WithMessage("ConfirmPassword is required!");
        }
    }
}
