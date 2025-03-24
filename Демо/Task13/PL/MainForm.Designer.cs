namespace WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctlTab = new System.Windows.Forms.TabControl();
            this.ctlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlRewardPage = new System.Windows.Forms.TabPage();
            this.ctlReward = new System.Windows.Forms.DataGridView();
            this.rewardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rewardTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rewardDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlUserPage = new System.Windows.Forms.TabPage();
            this.ctlUser = new System.Windows.Forms.DataGridView();
            this.userID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userBirthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserRewards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlMainMenu = new System.Windows.Forms.MenuStrip();
            this.ctlAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlAddReward = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlTab.SuspendLayout();
            this.ctlContextMenu.SuspendLayout();
            this.ctlRewardPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlReward)).BeginInit();
            this.ctlUserPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlUser)).BeginInit();
            this.ctlMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlTab
            // 
            this.ctlTab.ContextMenuStrip = this.ctlContextMenu;
            this.ctlTab.Controls.Add(this.ctlRewardPage);
            this.ctlTab.Controls.Add(this.ctlUserPage);
            this.ctlTab.Location = new System.Drawing.Point(12, 27);
            this.ctlTab.Name = "ctlTab";
            this.ctlTab.SelectedIndex = 0;
            this.ctlTab.Size = new System.Drawing.Size(832, 354);
            this.ctlTab.TabIndex = 2;
            // 
            // ctlContextMenu
            // 
            this.ctlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.editToolStripMenuItem});
            this.ctlContextMenu.Name = "ctlContextMenuReward";
            this.ctlContextMenu.Size = new System.Drawing.Size(155, 48);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removeToolStripMenuItem.Text = "Удалить";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editToolStripMenuItem.Text = "Редактировать";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // ctlRewardPage
            // 
            this.ctlRewardPage.Controls.Add(this.ctlReward);
            this.ctlRewardPage.Location = new System.Drawing.Point(4, 22);
            this.ctlRewardPage.Name = "ctlRewardPage";
            this.ctlRewardPage.Padding = new System.Windows.Forms.Padding(3);
            this.ctlRewardPage.Size = new System.Drawing.Size(824, 328);
            this.ctlRewardPage.TabIndex = 0;
            this.ctlRewardPage.Text = "Награды";
            this.ctlRewardPage.UseVisualStyleBackColor = true;
            // 
            // ctlReward
            // 
            this.ctlReward.AllowUserToAddRows = false;
            this.ctlReward.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ctlReward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlReward.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rewardID,
            this.rewardTitle,
            this.rewardDescription});
            this.ctlReward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlReward.Location = new System.Drawing.Point(3, 3);
            this.ctlReward.Name = "ctlReward";
            this.ctlReward.Size = new System.Drawing.Size(818, 322);
            this.ctlReward.TabIndex = 0;
            this.ctlReward.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ctlReward_ColumnHeaderMouseClick);
            // 
            // rewardID
            // 
            this.rewardID.DataPropertyName = "ID";
            this.rewardID.HeaderText = "ID";
            this.rewardID.Name = "rewardID";
            // 
            // rewardTitle
            // 
            this.rewardTitle.DataPropertyName = "Title";
            this.rewardTitle.HeaderText = "Название";
            this.rewardTitle.Name = "rewardTitle";
            // 
            // rewardDescription
            // 
            this.rewardDescription.DataPropertyName = "Description";
            this.rewardDescription.HeaderText = "Описание";
            this.rewardDescription.Name = "rewardDescription";
            // 
            // ctlUserPage
            // 
            this.ctlUserPage.Controls.Add(this.ctlUser);
            this.ctlUserPage.Location = new System.Drawing.Point(4, 22);
            this.ctlUserPage.Name = "ctlUserPage";
            this.ctlUserPage.Padding = new System.Windows.Forms.Padding(3);
            this.ctlUserPage.Size = new System.Drawing.Size(824, 328);
            this.ctlUserPage.TabIndex = 1;
            this.ctlUserPage.Text = "Пользователи";
            this.ctlUserPage.UseVisualStyleBackColor = true;
            // 
            // ctlUser
            // 
            this.ctlUser.AllowUserToAddRows = false;
            this.ctlUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ctlUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userID,
            this.userFirstName,
            this.userLastName,
            this.userBirthdate,
            this.userAge,
            this.UserRewards});
            this.ctlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlUser.Location = new System.Drawing.Point(3, 3);
            this.ctlUser.Name = "ctlUser";
            this.ctlUser.Size = new System.Drawing.Size(818, 322);
            this.ctlUser.TabIndex = 0;
            this.ctlUser.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ctlUser_ColumnHeaderMouseClick);
            // 
            // userID
            // 
            this.userID.DataPropertyName = "ID";
            this.userID.HeaderText = "ID";
            this.userID.Name = "userID";
            // 
            // userFirstName
            // 
            this.userFirstName.DataPropertyName = "FirstName";
            this.userFirstName.HeaderText = "Имя";
            this.userFirstName.Name = "userFirstName";
            // 
            // userLastName
            // 
            this.userLastName.DataPropertyName = "LastName";
            this.userLastName.HeaderText = "Фамилия";
            this.userLastName.Name = "userLastName";
            // 
            // userBirthdate
            // 
            this.userBirthdate.DataPropertyName = "Birthdate";
            this.userBirthdate.HeaderText = "Дата рождения";
            this.userBirthdate.Name = "userBirthdate";
            // 
            // userAge
            // 
            this.userAge.DataPropertyName = "Age";
            this.userAge.HeaderText = "Возраст";
            this.userAge.Name = "userAge";
            // 
            // UserRewards
            // 
            this.UserRewards.DataPropertyName = "UserRewards";
            this.UserRewards.HeaderText = "Награды";
            this.UserRewards.Name = "UserRewards";
            // 
            // ctlMainMenu
            // 
            this.ctlMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlAdd});
            this.ctlMainMenu.Location = new System.Drawing.Point(0, 0);
            this.ctlMainMenu.Name = "ctlMainMenu";
            this.ctlMainMenu.Size = new System.Drawing.Size(892, 24);
            this.ctlMainMenu.TabIndex = 3;
            this.ctlMainMenu.Text = "menuStrip1";
            // 
            // ctlAdd
            // 
            this.ctlAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlAddReward,
            this.ctlAddUser});
            this.ctlAdd.Name = "ctlAdd";
            this.ctlAdd.Size = new System.Drawing.Size(71, 20);
            this.ctlAdd.Text = "Добавить";
            // 
            // ctlAddReward
            // 
            this.ctlAddReward.Name = "ctlAddReward";
            this.ctlAddReward.Size = new System.Drawing.Size(151, 22);
            this.ctlAddReward.Text = "Награда";
            this.ctlAddReward.Click += new System.EventHandler(this.ctlAddReward_Click);
            // 
            // ctlAddUser
            // 
            this.ctlAddUser.Name = "ctlAddUser";
            this.ctlAddUser.Size = new System.Drawing.Size(151, 22);
            this.ctlAddUser.Text = "Пользователь";
            this.ctlAddUser.Click += new System.EventHandler(this.ctlAddUser_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 417);
            this.Controls.Add(this.ctlTab);
            this.Controls.Add(this.ctlMainMenu);
            this.MainMenuStrip = this.ctlMainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи и награды";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ctlTab.ResumeLayout(false);
            this.ctlContextMenu.ResumeLayout(false);
            this.ctlRewardPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlReward)).EndInit();
            this.ctlUserPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlUser)).EndInit();
            this.ctlMainMenu.ResumeLayout(false);
            this.ctlMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl ctlTab;
        private System.Windows.Forms.TabPage ctlRewardPage;
        private System.Windows.Forms.DataGridView ctlReward;
        private System.Windows.Forms.TabPage ctlUserPage;
        private System.Windows.Forms.DataGridView ctlUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn userID;
        private System.Windows.Forms.DataGridViewTextBoxColumn userFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn userLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn userBirthdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn userAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserRewards;
        private System.Windows.Forms.MenuStrip ctlMainMenu;
        private System.Windows.Forms.ToolStripMenuItem ctlAdd;
        private System.Windows.Forms.ToolStripMenuItem ctlAddReward;
        private System.Windows.Forms.ToolStripMenuItem ctlAddUser;
        private System.Windows.Forms.ContextMenuStrip ctlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn rewardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn rewardTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn rewardDescription;
    }
}

