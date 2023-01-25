using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.BLL.Services;
using WebNewsApp.Controllers;
using WebNewsApp.Models;
using WebNewsApp.Presenters;

namespace WebNewsApp.Views
{
    public partial class MainWindow : Form
    {
        public event EventHandler onSearchClick;
        public event EventHandler onResetClick;
        public event EventHandler onAccountClick;
        public event EventHandler onCreateClick;
        public event EventHandler onMyArticlesClick;
        public event EventHandler onArticleClick;
        public event EventHandler onFindChoice;

        public MainWindow()
        {
            InitializeComponent();
            this.newsList.SelectedIndexChanged += delegate { onArticleClick?.Invoke(this, EventArgs.Empty); };
            this.AccountLink.Click += delegate { onAccountClick?.Invoke(this, EventArgs.Empty); };
            this.searchButton.Click += delegate { onSearchClick?.Invoke(this, EventArgs.Empty); };
            this.resetButton.Click += delegate { onResetClick?.Invoke(this, EventArgs.Empty); };
            this.userArticles.Click += delegate { onMyArticlesClick?.Invoke(this, EventArgs.Empty); };
            this.findComboBox.SelectedValueChanged += delegate { onFindChoice?.Invoke(this, EventArgs.Empty); };
            this.createButton.Click += delegate { onCreateClick?.Invoke(this, EventArgs.Empty); };
        }

        public string AccountLinkText
        {
            set => AccountLink.Text = value;
        }

        public IEnumerable<string> NewsList { 
            get => newsList.Items.Cast<string>();
            set
            {
                newsList.Items.Clear();
                foreach (var item in value) 
                {
                    newsList.Items.Add(item);
                }
            }
        }
        public void AddNews(ListViewItem item)
        {
            newsList.Items.Add(item);
        }

        public DateTime StartTime
        {
            get => DateTime.Parse(dateTimeStart.Text);
        }
        public DateTime EndTime
        {
            get => DateTime.Parse(dateTimeEnd.Text);
        }

        public int SelectedArticleId
        {
            get => this.newsList.SelectedIndices[0];
        }

        public string ChoiceItem
        {
            get => findComboBox.Text;
        }

        public string InputText
        {
            get => inputBox.Text;
            set => inputBox.Text = value;
        }

        public void EnableDatePicker()
        {
            this.dateTimeStart.Enabled = true;
            this.dateTimeEnd.Enabled = true;
        }

        public void DisableDatePicker()
        {
            this.dateTimeStart.Enabled = false;
            this.dateTimeEnd.Enabled = false;
        }

        public void ClearNews()
        {
            this.newsList.Items.Clear();
        }
    }
}
