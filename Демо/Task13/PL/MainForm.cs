using System;
using UsersAndRewards.MainClasses.BLL;
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
    public partial class MainForm : Form
    {
        public static RewardsBL rewards = new RewardsBL();
        public static UsersBL users = new UsersBL();
        private enum RewardSortMode { Asceding, Desceding };
        private enum UserSortMode { Asceding, Desceding };
        private RewardSortMode rSortMode = RewardSortMode.Asceding;
        private UserSortMode uSortMode = UserSortMode.Asceding;
        public MainForm()
        {
            InitializeComponent();
        }

        public void DisplayRewards()
        {
            ctlReward.DataSource = RewardView.ShowRewards(rewards);
        }

        public void DisplayUsers()
        {
            ctlUser.DataSource = UserView.ShowUsers(users);
        }

        private void RegisterNewReward()
        {
            RewardForm form = new RewardForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var reward = new Reward();
                reward.Title = form.Title;
                reward.Description = form.Description;
                rewards.Add(reward);
                DisplayRewards();
            }
        }

        private void RegisterNewUser()
        {
            UserForm form = new UserForm();
            form.createNew = true;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                User user = new User();
                user.FirstName = form.FirstName;
                user.LastName = form.LastName;
                user.Birthdate = form.Birthdate;
                user.UserRewards = form.GetUsersRewards();
                users.Add(user);
                DisplayUsers();
            }
        }

        private void RemoveSelectedItem()
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if ((ctlTab.SelectedTab == ctlRewardPage) && (ctlReward.SelectedCells.Count > 0))
                {
                    var i = ctlReward.SelectedCells[0].OwningRow.Index;
                    var reward = new Reward();
                    int rewardID = (int)ctlReward[0, i].Value;
                    reward = rewards.Get(rewardID);
                    rewards.Delete(reward);
                    foreach(User user in users.GetList())
                    {
                        int rewIndex = user.UserRewards.IndexOf(user.UserRewards.Find(x => x.ID == reward.ID));
                        if (rewIndex >= 0)
                        {
                            user.UserRewards.Remove(reward);
                        }
                    }
                }
                if ((ctlTab.SelectedTab == ctlUserPage) && (ctlUser.SelectedCells.Count > 0))
                {
                    var i = ctlUser.SelectedCells[0].OwningRow.Index;
                    var user = new User();
                    int userID = (int)ctlUser[0, i].Value;
                  //  user = users.Get(userID);
                    users.Delete(users.Get(userID));
                }
            }
        }

        private void EditSelectedItem()
        {
            if ((ctlTab.SelectedTab == ctlRewardPage) && (ctlReward.SelectedCells.Count > 0))
                {
                var i = ctlReward.SelectedCells[0].OwningRow.Index;
                int rewardID = (int)ctlReward[0, i].Value;
                int rewIndex = rewards.IndexOf(rewards.Get(rewardID));
                RewardForm form = new RewardForm();
                form.createNew = false;
                form.Description = rewards.Get(rewardID).Description;
                form.Title = rewards.Get(rewardID).Title;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    rewards.Edit(rewardID, form.Title, form.Description);
                }
                foreach (User user in users.GetList())
                {
                    int rIndex = user.UserRewards.IndexOf(user.UserRewards.Find(x => x.ID == rewards[rewIndex].ID));
                    if (rIndex >= 0)
                    {
                        user.UserRewards[rIndex] = rewards[rewIndex];
                    }
                }
            }
            if ((ctlTab.SelectedTab == ctlUserPage) && (ctlUser.SelectedCells.Count > 0))
            {
                var i = ctlUser.SelectedCells[0].OwningRow.Index;
                int userID = (int)ctlUser[0, i].Value;
                int usIndex = users.IndexOf(users.Get(userID));
                UserForm form = new UserForm();
                form.createNew = false;
                form.FirstName = users.Get(userID).FirstName;
                form.LastName = users.Get(userID).LastName;
                form.Birthdate = users.Get(userID).Birthdate;
                form.UserRewards = users.Get(userID).UserRewards;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    users.Edit(userID, form.FirstName, form.LastName, form.Birthdate, form.GetUsersRewards());
                }
            }
        }

        private void ctlAddReward_Click(object sender, EventArgs e)
        {
            RegisterNewReward();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ctlReward.DataSource = rewards;
            ctlUser.DataSource = users;
            DisplayRewards();
            DisplayUsers();
        }

        private void ctlAddUser_Click(object sender, EventArgs e)
        {
            RegisterNewUser();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedItem();
            DisplayRewards();
            DisplayUsers();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
            DisplayRewards();
            DisplayUsers();
        }

        private void ctlReward_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (rSortMode == RewardSortMode.Asceding)
                {
                    ctlReward.DataSource = RewardView.ShowRewards(rewards.SortByTitleDesc());
                    rSortMode = RewardSortMode.Desceding;
                }
                else
                {
                    ctlReward.DataSource = RewardView.ShowRewards(rewards.SortByTitleAsc());
                    rSortMode = RewardSortMode.Asceding;
                }
            }
            if (e.ColumnIndex == 2)
            {
                if (rSortMode == RewardSortMode.Asceding)
                {
                    ctlReward.DataSource = RewardView.ShowRewards(rewards.SortByDescriptionDesc());
                    rSortMode = RewardSortMode.Desceding;
                }
                else
                {
                    ctlReward.DataSource = RewardView.ShowRewards(rewards.SortByDescriptionAsc());
                    rSortMode = RewardSortMode.Asceding;
                }
            }
        }

        private void ctlUser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (uSortMode == UserSortMode.Asceding)
                {
                    ctlUser.DataSource = UserView.ShowUsers(users.SortByFirstNameDesc());
                    uSortMode = UserSortMode.Desceding;
                }
                else
                {
                    ctlUser.DataSource = UserView.ShowUsers(users.SortByFirstNameAsc());
                    uSortMode = UserSortMode.Asceding;
                }
            }
            if (e.ColumnIndex == 2)
            {
                if (uSortMode == UserSortMode.Asceding)
                {
                    ctlUser.DataSource = UserView.ShowUsers(users.SortByLastNameDesc());
                    uSortMode = UserSortMode.Desceding;
                }
                else
                {
                    ctlUser.DataSource = UserView.ShowUsers(users.SortByLastNameAsc());
                    uSortMode = UserSortMode.Asceding;
                }
            }
        }
    }
}
