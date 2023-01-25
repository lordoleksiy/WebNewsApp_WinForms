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
    public partial class ArticleViewerWindow : Form
    {
        public event EventHandler backToMainWindowClicked;
        public ArticleViewerWindow()
        {
            InitializeComponent();
            mainWindow.Click += delegate { backToMainWindowClicked?.Invoke(this, EventArgs.Empty); };
        }

        public string Header
        {
            set => header.Text = value;
        }

        public string PublishedTime
        {
            set => publishedTime.Text = value;
        }

        public string Description
        {
            set => descriptionBox.Text = value;
        }

        public IEnumerable<string> TagList
        {
            set { 
                foreach (var tag in value)
                {
                    tagListBox.Items.Add(tag);
                }
            }
        }

        public IEnumerable<string> Categories
        {
            set
            {
                foreach (var category in value)
                {
                    categoryListBox.Items.Add(category);
                }
            }
        }

        public IEnumerable<string> Authors
        {
            set
            {
                foreach (var author in value)
                {
                    authorListBox.Items.Add(author);
                }
            }
        }




        
    }
}
