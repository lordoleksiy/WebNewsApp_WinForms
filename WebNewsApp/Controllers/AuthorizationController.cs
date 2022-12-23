using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Infrastructure;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.Models;

namespace WebNewsApp.Controllers
{
    public class AuthorizationController
    {
        private readonly IAuthorizationService _service;
        public AuthorizationController(IAuthorizationService service)
        {
            _service = service;
        }

        public bool Register(UserViewModel user)
        {
            var userDTO = new UserDTO()
            {
                Password = user.Password,
                Login = user.Login,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                Description = user.Description,
            };
            try
            {
                _service.Register(userDTO);
            }
            catch (ValidationException ex)
            {
                return false;
            }
            return true;
        }
        public UserViewModel LogIn(UserViewModel user)
        {
            UserDTO userDTO;
            try 
            { 
                userDTO = _service.Login(user.Login, user.Password); 
            }
            catch(ValidationException ex)
            {
                return null;
            }
            return new UserViewModel()
            {
                Id = userDTO.Id,
                Email = userDTO.Email,
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                Description = userDTO.Description,
                RegisterDate = userDTO.RegisterDate
            };
        }
    }
}
