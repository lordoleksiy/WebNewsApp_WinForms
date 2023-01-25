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
        public event EventHandler loginButtonClicked;
        public event EventHandler linkClicked;
        public event EventHandler backToMainWindowClicked;
        public AuthorizationWindow()
        {  
            InitializeComponent();
            loginButton.Click += delegate { loginButtonClicked?.Invoke(this, EventArgs.Empty); };
            mainWindow.Click += delegate { backToMainWindowClicked?.Invoke(this, EventArgs.Empty); };
            accountLink.Click += delegate { linkClicked?.Invoke(this, EventArgs.Empty); };
        }

        public string LoginInput
        {
            get => loginInput.Text;
            set => loginInput.Text = value;
        }
        public string PasswordInput
        {
            get => this.passwordInput.Text;
            set => this.passwordInput.Text = value;
        }
        public string WarningLabel
        {
            get => warningLabel.Text;
            set => warningLabel.Text = value;
        }
    }
}
