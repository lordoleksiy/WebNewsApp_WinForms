using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using WebNewsApp.BLL.DTO;

namespace WebNewsApp.BLL.Infrastructure
{
    public class UserValidator: AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(x => x.Login).NotEmpty().Length(4, 15);
            RuleFor(x => x.Name).NotEmpty().Length(1, 20);
            RuleFor(x => x.Surname).Length(1, 20);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotNull().NotEmpty().Length(4, 20);
        }
    }
}
