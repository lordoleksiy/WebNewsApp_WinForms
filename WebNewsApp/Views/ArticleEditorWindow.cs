using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.Controllers;
using WebNewsApp.Models;

namespace WebNewsApp.Views
{
    public partial class ArticleEditorWindow : Form
    {
        
        public event EventHandler onBackToMainWindowClicked;
        public event EventHandler onSaveClicked;
        public event EventHandler onAddTagClicked;
        public event EventHandler onAddAuthorClicked;
        public event EventHandler onTagChecked;
        public event EventHandler onAuthorChecked;
        public event EventHandler onDeleteClicked;
        public ArticleEditorWindow()
        {   
            InitializeComponent();
            mainWindow.Click += delegate { onBackToMainWindowClicked?.Invoke(this, EventArgs.Empty); };
            saveButton.Click += delegate { onSaveClicked?.Invoke(this, EventArgs.Empty); };
            addTagButton.Click += delegate { onAddTagClicked?.Invoke(this, EventArgs.Empty); }; 
            addAuthorButton.Click += delegate { onAddAuthorClicked?.Invoke(this, EventArgs.Empty); };
            tagListBox.SelectedIndexChanged += delegate { onTagChecked?.Invoke(this, EventArgs.Empty); };
            authorListBox.SelectedIndexChanged += delegate { onAuthorChecked?.Invoke(this, EventArgs.Empty); };
            deleteLink.Click += delegate { onDeleteClicked?.Invoke(this, EventArgs.Empty); };
        }

        public string Header
        {
            get => headerBox.Text;
            set => headerBox.Text = value;
        }
        public string Description
        {
            get => descriptionBox.Text;
            set => descriptionBox.Text = value;
        }
        public string TagText
        {
            get => tagBox.Text;
            set => tagBox.Text = value;
        }
        public string AuthorText
        {
            get => authorBox.Text;
            set => authorBox.Text = value;
        }

        public IEnumerable<string> TagList
        {
            set
            {
                foreach (var tag in value)
                {
                    tagListBox.Items.Add(tag);
                }
            }
            get => tagListBox.Items.Cast<string>();
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
            get => categoryListBox.SelectedItems.Cast<string>();
        }

        public IEnumerable<string> SelectedCategories
        {
            get => categoryListBox.SelectedItems.Cast<string>();
            set
            {
                foreach (var category in value)
                {
                    categoryListBox.SelectedItems.Add(category);
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
            get => authorListBox.Items.Cast<string>();
        }

        public string SelectedAuthor
        {
            get => authorListBox.SelectedItem.ToString();
        }

        public string SelectedTag
        {
            get => tagListBox.SelectedItem.ToString();
        }

        public void RemoveAuthor(string Login)
        {
            authorListBox.Items.Remove(Login);
        }

        public void RemoveTag(string tagName)
        {
            tagListBox.Items.Remove(tagName);
        }

        public void AddTag(string tag)
        {
            tagListBox.Items.Add(tag);
        }

        public void AddUser(string user)
        {
            authorListBox.Items.Add(user);
        }


    }
}
