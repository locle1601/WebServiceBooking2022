using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceBooking.ViewModels.Contents
{
   public class BranchCreateRequestValidator : AbstractValidator<BranchCreateRequest>
    {
        public BranchCreateRequestValidator()
        {
            RuleFor(x => x.BranchName).NotEmpty().WithMessage("Branch Name is required");
        }

    }
}
