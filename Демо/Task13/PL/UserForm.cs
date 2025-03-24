using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace WinForms
{
    public partial class UserForm : Form
    {
        public bool createNew = true;
        public string FirstName;
        public string LastName;
        public DateTime Birthdate;
        Dictionary<int, CheckBox> rewDict = new Dictionary<int, CheckBox>();
        public List<Reward> UserRewards = new List<Reward>();

        public UserForm()
        {
            InitializeComponent();
        }

        public List<Reward> GetUsersRewards()
        {
            var rewList = new List<Reward>();
            foreach(var item in rewDict)
            {
                if (item.Value.Checked)
                {
                    var newRew = new Reward();
                    newRew = MainForm.rewards.Get(item.Key);
                    rewList.Add(newRew);
                }
            }
            return rewList;
        }

        private void userForm_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = FirstName;
            txtLastName.Text = LastName;
            int k = 0;
            foreach(Reward award in MainForm.rewards.GetList())
            {
                CheckBox chk = new CheckBox();
                chk.Location = new Point(10, 20*k);
                chk.Text = award.Title;
                if ((UserRewards != null) && (UserRewards.Contains(award)))
                {
                    chk.Checked = true;
                }
                pnlRewards.Controls.Add(chk);
                rewDict.Add(award.ID, chk);
                k++;
            }
            if (createNew)
            {
                Text = "Добавить нового пользователя";
                btnOK.Text = "Добавить";
            }
            else
            {
                Text = "Редактировать пользователя";
                btnOK.Text = "Редакт.";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = ValidateChildren() ? DialogResult.OK : DialogResult.None;
        }

        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            FirstName = txtFirstName.Text.Trim();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            string input = txtFirstName.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider.SetError(txtFirstName, "Введите имя!");
                e.Cancel = true;
            }
            else if (input.Length > 50)
            {
                errorProvider.SetError(txtFirstName, "Максимальная длина - 50!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtFirstName, String.Empty);
                e.Cancel = false;
            }
        }

        private void txtLastName_Validated(object sender, EventArgs e)
        {
            LastName = txtLastName.Text.Trim();
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            string input = txtLastName.Text.Trim();

            if (String.IsNullOrEmpty(input))
            {
                errorProvider.SetError(txtLastName, "Введите фамилию!");
                e.Cancel = true;
            }
            else if (input.Length > 50)
            {
                errorProvider.SetError(txtLastName, "Максимальная длина - 50!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLastName, String.Empty);
                e.Cancel = false;
            }
        }

        private void dateTimePicker_Validated(object sender, EventArgs e)
        {
            Birthdate = dateTimePicker.Value.Date;
        }

        private void dateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            DateTime date = dateTimePicker.Value.Date;
            if (date > DateTime.Now)
            {
                errorProvider.SetError(dateTimePicker, "Некорректная дата!");
                e.Cancel = true;
            }
            else if (DateTime.Now.Year - date.Year >= 150)
            {
                errorProvider.SetError(dateTimePicker, "Некорректная дата!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLastName, String.Empty);
                e.Cancel = false;
            }
        }

    }
}
