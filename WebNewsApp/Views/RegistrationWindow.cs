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
    public partial class RegistrationWindow : Form
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
        }
    }
}
