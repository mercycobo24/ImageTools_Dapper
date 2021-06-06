using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FluentValidation;
using ImageTool;
using ImageTool.Models;

namespace ImageTool.Validators
{
    public class EntityImagesCommandValidator : AbstractValidator<EntityImagesCommand>
    {
        public EntityImagesCommandValidator()
        {

            RuleFor(x => x.EntityImages.Count).GreaterThan(0).WithMessage("Images must be submitted");

          //  RuleForEach(x => x.EntityImages).Must((n=>  n.URL !=""));

            RuleForEach(x => x.EntityImages).SetValidator(new EntityImageValidator());

            
         }
    }
}
