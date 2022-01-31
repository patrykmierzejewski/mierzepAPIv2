using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Application.Authors.Command.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(10);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(300);
        }
    }
}
