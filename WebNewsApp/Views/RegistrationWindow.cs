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
        public event EventHandler registerButtonClicked;
        public event EventHandler linkClicked;
        public event EventHandler backToMainWindowClicked;

        public RegistrationWindow()
        {
            InitializeComponent();
            registerButton.Click += delegate { registerButtonClicked?.Invoke(this, EventArgs.Empty); };
            mainWindow.Click += delegate { backToMainWindowClicked?.Invoke(this, EventArgs.Empty); };
            accountLink.Click += delegate { linkClicked?.Invoke(this, EventArgs.Empty); };
        }
        public string Login
        {
            get => loginBox.Text;
            set => loginBox.Text = value;
        }
        public string Password
        {
            get => this.passwordBox.Text;
            set => this.passwordBox.Text = value;
        }
        public string Email
        {
            get => emailBox.Text;
            set => emailBox.Text = value;
        }
        public string NameInput
        {
            get => nameBox.Text;
            set => nameBox.Text = value;
        }
        public string SurnameInput
        {
            get => surnameBox.Text;
            set => surnameBox.Text = value;
        }
        public string Password2
        {
            get => passwordBox2.Text;
            set => passwordBox2.Text = value;
        }
        public string WarningLabel
        {
            get => warningLabel.Text;
            set => warningLabel.Text = value;
        }
    }
}
