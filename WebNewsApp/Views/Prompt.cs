using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebNewsApp.Views
{
    public class Prompt: IDisposable
    {
        private Form prompt { get; set; }
        public string Result { get; }
        public Prompt(string text)
        {
            Result = ShowDialog(text);
        }
        public string ShowDialog(string text)
        {
           prompt = new Form()
           {
                Width = 350,
                Height = 170,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Dialog Bar",
                StartPosition = FormStartPosition.CenterScreen
           };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 250 };
            TextBox textBox = new TextBox() { Left = 50, Top = 40, Width =  250, PasswordChar='*'};
            Button confirmButton = new Button() { Text = "Ok", Left = 125, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmButton.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmButton);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmButton;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return textBox.Text;
            }
            return null;
        }

        public void Dispose()
        {
            if (prompt != null)
            {
                prompt.Dispose();
            }
        }
    }
}
