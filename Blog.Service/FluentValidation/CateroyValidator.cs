using Blog.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.FluentValidation
{
    public class CateroyValidator : AbstractValidator<Category>
    {
        public CateroyValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .NotNull()
               .MaximumLength(151)
               .MinimumLength(3)
               .WithName("Kategori adı ");
        }
    }
}
