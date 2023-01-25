using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Infrastructure;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.Models;
using WebNewsApp.Presenters;
using WebNewsApp.Views;

namespace WebNewsApp.Controllers
{
    public class AuthorizationPresenter
    {
        private readonly IAuthorizationService _service;
        private readonly AuthorizationWindow _window;
        
        public AuthorizationPresenter(AuthorizationWindow window)
        {
            _window = window;
            IKernel kernel = Program.Kernel;
            _service = kernel.Get<IAuthorizationService>();
            _window.Show();

            _window.linkClicked += LinkClicked;
            _window.backToMainWindowClicked += BackToMainWindow;
            _window.loginButtonClicked += LoginButtonClicked;
        }
        public void LinkClicked(object sender, EventArgs e)
        {
            _window.Close();
            new RegistrationPresenter(new RegistrationWindow());
        }

        public void BackToMainWindow(object sender, EventArgs e)
        {
            _window.Close();
            new MainPresenter(new MainWindow());
            
        }

        public void LoginButtonClicked(object sender, EventArgs e)
        {
            _window.WarningLabel = "";
            var login = _window.LoginInput;
            var pass = _window.PasswordInput;
            UserViewModel user;

            try
            {
                user = LogIn(login, pass);
                _window.Close();
                AccountPresenter.Set(user);
                new MainPresenter(new MainWindow());
                
            }
            catch (ValidationException ex)
            {
                _window.WarningLabel = ex.Message;
            }
        }

        public UserViewModel LogIn(string login, string password)
        {
            UserDTO userDTO;
            var user = new UserViewModel();
            userDTO = _service.Login(login, password);
  
            user.Id = userDTO.Id;
            user.Email = userDTO.Email;
            user.Login = userDTO.Login;
            user.Name = userDTO.Name;
            user.Surname = userDTO.Surname;
            user.Password = userDTO.Password;
            user.Description = userDTO.Description;
            user.RegisterDate = userDTO.RegisterDate;

            return user;
        }
    }
}
