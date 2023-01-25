using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.Controllers;
using WebNewsApp.Models;
using WebNewsApp.Views;

namespace WebNewsApp.Presenters
{
    public class OwnAccountPresenter
    {
        private readonly IUserManagerService _service;
        private readonly OwnAccountWindow _window;

        public OwnAccountPresenter(OwnAccountWindow window)
        {
            _window = window;
            IKernel kernel = Program.Kernel;
            _service = kernel.Get<IUserManagerService>();
            _window.Show();

            _window.backToMainWindowClicked += BackToMainWindow;
            _window.saveClicked += SaveAccount;
            _window.exitFromAccountClicked += ExitAccount;
            _window.deleteAccountClicked += DeleteAccount;
        }

        public void SaveAccount(object sender, EventArgs e)
        {
            var login = _window.Login;
            var name = _window.NameInput;
            var surname = _window.SurnameInput;
            var email = _window.Email;
            var password = _window.Password;
            var description = _window.Description;

            var user = AccountPresenter.Get();
            using (Prompt prompt = new Prompt("Enter old password:"))
            {
                var result = prompt.Result;
                if (result != null && result.Equals(user.Password))
                {
                    var userDTO = new UserDTO()
                    {
                        Id = user.Id,
                        Login = login,
                        Name = name,
                        Surname = surname,
                        Email = email,
                        Password = password,
                        Description = description
                    };
                    try
                    {
                        _service.Update(userDTO);
                        _window.WarningLabel = "Data is updated!";
                        AccountPresenter.Set(
                            new UserViewModel()
                            {
                                Id = userDTO.Id,
                                Login = userDTO.Login,
                                Name = userDTO.Name,
                                Surname = userDTO.Surname,
                                Email = userDTO.Email,
                                Password = userDTO.Password,
                                Description = userDTO.Description
                            }
                            );

                    }
                    catch (Exception ex)
                    {
                        _window.WarningLabel = ex.Message;
                    }
                }
            }
        }

        public void DeleteAccount(object sender, EventArgs e)
        {
            var user = AccountPresenter.Get();
            using (Prompt prompt = new Prompt("Enter password to delete your account:"))
            {
                var result = prompt.Result;
                if (result != null && result == user.Password)
                {
                    try
                    {
                        _service.Delete(user.Id);
                        AccountPresenter.Reset();
                        _window.Close();
                        new MainPresenter(new MainWindow());
                        
                    }
                    catch (Exception ex)
                    {
                        _window.WarningLabel = ex.Message;
                    }
                }
            }
        }

        public void ExitAccount(object sender, EventArgs e)
        {
            AccountPresenter.Reset();
            _window.Close();
            new MainPresenter(new MainWindow());
            
        }

        public void BackToMainWindow(object sender, EventArgs e)
        {
            _window.Close();
            new MainPresenter(new MainWindow());
            
        }
    }
}
