using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebNewsApp.Views
{
    public partial class OwnAccountWindow : Form
    {
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
            Prompt.ShowDialog("test", "123");

        }
    }
}
