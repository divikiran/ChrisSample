using System;
using FluentValidation;

namespace ChrisSample
{
    public class PageValidation : AbstractValidator<MainViewModel>
    {
        public PageValidation()
        {
            RuleFor(x => x.Name).NotEmpty().OnFailure(x => x.NameError = "Name is Empty");
            RuleFor(x => x.Name).NotNull().OnFailure(x => x.NameError = "Name is Null");
            


        }
    }
}
