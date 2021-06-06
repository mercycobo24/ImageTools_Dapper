using FluentValidation;
using ImageTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageTool.Validators
{
    public class EntityImageValidator : AbstractValidator<EntityImage>
    {
        public EntityImageValidator()
        {

            RuleFor(x => x.URL).NotEmpty().WithMessage("URL must be submitted");
            RuleFor(x => x.EntityId).NotEmpty().WithMessage("Entity Id must be submiited");

        }
    }
    
}
