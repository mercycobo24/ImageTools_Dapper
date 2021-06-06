using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ImageTool.Models;

namespace ImageTool.Validators
{
    public class EntityImagesRequestValidator : AbstractValidator<EntityImagesRequest>
    {
        public EntityImagesRequestValidator()
        {
           RuleFor(x => x.EntityId).NotEmpty();
        }
    }
}
