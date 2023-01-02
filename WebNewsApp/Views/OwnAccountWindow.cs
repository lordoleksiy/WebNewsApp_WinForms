using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.Controllers;
using WebNewsApp.Models;

namespace WebNewsApp.Views
{
    public partial class OwnAccountWindow : Form
    {
        private static readonly UserManagerController _userManagerController;
        static OwnAccountWindow()
        {
            IKernel kernel = Program.Kernel;
            var userManagerService = kernel.Get<IUserManagerService>();
            _userManagerController = new UserManagerController(userManagerService);
        }
        public OwnAccountWindow()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var login = this.loginBox.Text;
            var name = this.nameBox.Text;
            var surname = this.surnameBox.Text;
            var email = this.emailBox.Text;
            var password = this.passwordBox.Text;
            var description = this.descriptionBox.Text;

            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(name)
                || String.IsNullOrEmpty(surname) || String.IsNullOrEmpty(password))
            {
                this.warningLabel.Text = "Input in all fields";
                return;
            }

            var user = AccountController.Get();
            using (Prompt prompt = new Prompt("Enter old password:"))
            {
                var result = prompt.Result;
                if (result != null && result.Equals(user.Password))
                {
                    user = _userManagerController.UpdateUser(new UserViewModel()
                    {
                        Id = user.Id,
                        Login = login,
                        Name = name,
                        Surname = surname,
                        Email = email,
                        Password = password,
                        Description = description
                    });
                    AccountController.Set(user);
                    this.warningLabel.Text = user.ErrorStatus != null ? user.ErrorStatus.ToString() : "Data is updated!";
                }
            }
        }

        private void OwnAccountWindow_Load(object sender, EventArgs e)
        {
            var user = AccountController.Get();
            this.loginBox.Text = user.Login;
            this.nameBox.Text = user.Name;
            this.surnameBox.Text = user.Surname;
            this.emailBox.Text = user.Email;
            this.passwordBox.Text = user.Password;
            this.dateBox.Text = user.RegisterDate.ToString();
            this.descriptionBox.Text = user.Description;
        }

        private void DeleteLink_Click(object sender, EventArgs e)
        {
            var user = AccountController.Get();
            String res = null;
            using (Prompt prompt = new Prompt("Enter password to delete your account:"))
            {
                var result = prompt.Result;
                if (result != null && result == user.Password)
                {
                    res = _userManagerController.DeleteUser(user.Id);
                    AccountController.Reset();
                }
            }

            if (res != null)
            {
                this.warningLabel.Text = res;
            }
            else
            {
                this.Close();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }

        private void exitLabel_Click(object sender, EventArgs e)
        {
            AccountController.Reset();
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
