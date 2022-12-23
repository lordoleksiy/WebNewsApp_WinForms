using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebNewsApp.Models;

namespace WebNewsApp.Views
{
    public partial class MainWindow : Form
    {
        private static readonly UserViewModel account; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (account == null)
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
            }
            else
            {

            }
        }
    }
}
