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
        public event EventHandler backToMainWindowClicked;
        public event EventHandler saveClicked;
        public event EventHandler deleteAccountClicked;
        public event EventHandler exitFromAccountClicked;

        public OwnAccountWindow()
        {
            InitializeComponent();
            backButton.Click += delegate { backToMainWindowClicked?.Invoke(this, EventArgs.Empty); };
            deleteLink.Click += delegate { deleteAccountClicked?.Invoke(this, EventArgs.Empty); };
            saveButton.Click += delegate { saveClicked?.Invoke(this, EventArgs.Empty); };
            exitLink.Click += delegate { exitFromAccountClicked?.Invoke(this, EventArgs.Empty); };
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
        public string Description
        {
            get => descriptionBox.Text;
            set => descriptionBox.Text = value;
        }
        public string WarningLabel
        {
            get => warningLabel.Text;
            set => warningLabel.Text = value;
        }

        private void OwnAccountWindow_Load(object sender, EventArgs e)
        {
            var user = AccountPresenter.Get();
            this.loginBox.Text = user.Login;
            this.nameBox.Text = user.Name;
            this.surnameBox.Text = user.Surname;
            this.emailBox.Text = user.Email;
            this.passwordBox.Text = user.Password;
            this.dateBox.Text = user.RegisterDate.ToString();
            this.descriptionBox.Text = user.Description;
        }
    }
}
