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
using WebNewsApp.BLL.Services;
using WebNewsApp.Controllers;

namespace WebNewsApp.Views
{
    public partial class AuthorizationWindow : Form
    {
        private static readonly AuthorizationController _authorizationController;
        
        static AuthorizationWindow()
        {
            IKernel kernel = Program.Kernel;
            var authorizationService = kernel.Get<IAuthorizationService>(); ;
            _authorizationController = new AuthorizationController(authorizationService);
        }
        public AuthorizationWindow()
        {  
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var login = this.loginInput.Text;
            var pass = this.passwordInput.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                this.warningLabel.Text = "Fill in all fields";
            }

            var user = _authorizationController.LogIn(login, pass);
            if (user.ErrorStatus != null)
            {
                this.warningLabel.Text = user.ErrorStatus;
            }
            else
            {
                this.Close();
                AccountController.Set(user);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
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
