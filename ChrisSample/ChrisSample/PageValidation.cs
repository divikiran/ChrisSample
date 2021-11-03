using System;
using FluentValidation;

namespace ChrisSample
{
    public class PageValidation : AbstractValidator<MainViewModel>
    {
        public PageValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().OnFailure(x => x.NameError = "Name is Missing");
            

        }
    }
}
