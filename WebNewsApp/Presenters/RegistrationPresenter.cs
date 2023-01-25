using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.Controllers;
using WebNewsApp.Models;
using WebNewsApp.Views;

namespace WebNewsApp.Presenters
{
    public class RegistrationPresenter
    {
        private readonly IAuthorizationService _service;
        private readonly RegistrationWindow _window;

        public RegistrationPresenter(RegistrationWindow window)
        {
            _window = window;
            IKernel kernel = Program.Kernel;
            _service = kernel.Get<IAuthorizationService>();
            _window.Show();

            _window.linkClicked += LinkClicked;
            _window.backToMainWindowClicked += BackToMainWindow;
            _window.registerButtonClicked += RegisterButtonClicked;
        }
        public void RegisterButtonClicked(object sender, EventArgs e)
        {
            _window.WarningLabel = "";
            var login = _window.Login;
            var email = _window.Email;
            var name = _window.Name;
            var surname = _window.SurnameInput;
            var password = _window.Password;
            var password2 = _window.Password2;

            if (!password.Equals(password2))
            {
                _window.WarningLabel = "Your password1 not equals to password2!";
                return;
            }

            var userDTO = new UserDTO()
            {
                Login = login,
                Email = email,
                Name = name,
                Surname = surname,
                Password = password,
            };

            try
            {
                userDTO = _service.Register(userDTO);
                var user = new UserViewModel()
                {
                    Id = userDTO.Id,
                    Login = userDTO.Login,
                    Email = userDTO.Email,
                    Name = userDTO.Name,
                    Surname = userDTO.Surname,
                    Password = userDTO.Password
                };
                AccountPresenter.Set(user);

                _window.Close();
                new MainPresenter(new MainWindow());
                
                MessageBox.Show("You are successfully registretated!");
            }
            catch (BLL.Infrastructure.ValidationException ex)
            {
                _window.WarningLabel = ex.Message + ": " + ex.Property;
            }
        }

        public void LinkClicked(object sender, EventArgs e)
        {
            _window.Close();
            new AuthorizationPresenter(new AuthorizationWindow());
        }

        public void BackToMainWindow(object sender, EventArgs e)
        {
            _window.Close();
            new MainPresenter(new MainWindow());
        }
    }
}
