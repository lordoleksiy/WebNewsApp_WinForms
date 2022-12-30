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

        public string Register(UserViewModel user)
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
                return ex.Message;
            }
            return null;
        }
        public UserViewModel LogIn(string login, string password)
        {
            UserDTO userDTO;
            var user = new UserViewModel(); 
            try 
            { 
                userDTO = _service.Login(login, password); 
            }
            catch(ValidationException ex)
            {
                user.ErrorStatus = ex.Message;
                return user;
            }
            
            user.Id = userDTO.Id;
            user.Email = userDTO.Email;
            user.Login = userDTO.Login;
            user.Name = userDTO.Name;
            user.Surname = userDTO.Surname;
            user.Description = userDTO.Description;
            user.RegisterDate = userDTO.RegisterDate;

            return user;
        }
    }
}
