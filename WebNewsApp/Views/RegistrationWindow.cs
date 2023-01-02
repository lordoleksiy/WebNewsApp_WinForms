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
    public partial class RegistrationWindow : Form
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly AuthorizationController _authorizationController;

        public RegistrationWindow()
        {
            IKernel kernel = Program.Kernel;
            _authorizationService = kernel.Get<IAuthorizationService>();
            _authorizationController = new AuthorizationController(_authorizationService);
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = this.loginBox.Text;
            var email = this.emailBox.Text;
            var name = this.nameBox.Text;
            var surname = this.surnameBox.Text;
            var password = this.passwordBox.Text;
            var password2 = this.password2Box.Text;
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(name) 
                || String.IsNullOrEmpty(surname) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(password2))
            {
                this.warningLabel.Text = "Input in all fields";
                return;
            }   
            if (!password.Equals(password2))
            {
                this.warningLabel.Text = "Your password1 not equals to password2!";
                return;
            }
            UserViewModel user = new UserViewModel()
            {
                Login = login,
                Email = email,
                Name = name,
                Surname = surname,
                Password = password,
            };
            var  account = _authorizationController.Register(user);

            if (account.ErrorStatus != null)
            {
                this.warningLabel.Text = account.ErrorStatus;
            }
            else
            {
                AccountController.Set(account);
                this.Close();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                MessageBox.Show("You are successfully registretated!");
            }
        }

        private void mainWindow_Click(object sender, EventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
