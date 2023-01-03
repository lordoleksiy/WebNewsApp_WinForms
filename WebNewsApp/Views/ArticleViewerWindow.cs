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
    public partial class ArticleViewerWindow : Form
    {
        public ArticleViewerWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Click(object sender, EventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
