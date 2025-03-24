using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class RewardForm : Form
    {
        public bool createNew = true;
        public string Title { get; set; }
        public string Description { get; set; }
        public RewardForm()
        {
            InitializeComponent();
        }

        private void RewardForm_Load(object sender, EventArgs e)
        {
            txtTitle.Text = Title;
            txtDescription.Text = Description;
            if (createNew)
            {
                Text = "Добавить новую награду";
                btnOK.Text = "Добавить";
            }
            else
            {
                Text = "Редактировать награду";
                btnOK.Text = "Редакт.";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
        }

        private void txtTitle_Validated(object sender, EventArgs e)
        {
            Title = txtTitle.Text.Trim();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            string input = txtTitle.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider.SetError(txtTitle, "Введите название!");
                e.Cancel = true;
            }
            else if (input.Length > 50)
            {
                errorProvider.SetError(txtTitle, "Максимальная длина - 50!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTitle, String.Empty);
                e.Cancel = false;
            }
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Description = txtDescription.Text.Trim();
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            string input = txtDescription.Text.Trim();
            if (input.Length > 250)
            {
                errorProvider.SetError(txtDescription, "Максимальная длина - 250!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtDescription, String.Empty);
                e.Cancel = false;
            }
        }
    }
}
