namespace UIL
{
	partial class frmCreateTeam
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtTeamName = new System.Windows.Forms.TextBox();
			this.teamNameLabel = new System.Windows.Forms.Label();
			this.headerlabel = new System.Windows.Forms.Label();
			this.btnAddMember = new System.Windows.Forms.Button();
			this.cbSelectTeamMember = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCreateMember = new System.Windows.Forms.Button();
			this.txtCellPhone = new System.Windows.Forms.TextBox();
			this.cellPhoneLabel = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.emailLabel = new System.Windows.Forms.Label();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.lastNameLabel = new System.Windows.Forms.Label();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.firstNameLabel = new System.Windows.Forms.Label();
			this.lstTeamMembers = new System.Windows.Forms.ListBox();
			this.btnRemoveSelectedMember = new System.Windows.Forms.Button();
			this.btnCreateTeam = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtTeamName
			// 
			this.txtTeamName.Location = new System.Drawing.Point(37, 131);
			this.txtTeamName.Name = "txtTeamName";
			this.txtTeamName.Size = new System.Drawing.Size(398, 33);
			this.txtTeamName.TabIndex = 13;
			// 
			// teamNameLabel
			// 
			this.teamNameLabel.AutoSize = true;
			this.teamNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.teamNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.teamNameLabel.Location = new System.Drawing.Point(30, 80);
			this.teamNameLabel.Name = "teamNameLabel";
			this.teamNameLabel.Size = new System.Drawing.Size(261, 37);
			this.teamNameLabel.TabIndex = 12;
			this.teamNameLabel.Text = "Название команды:";
			// 
			// headerlabel
			// 
			this.headerlabel.AutoSize = true;
			this.headerlabel.Font = new System.Drawing.Font("Segoe UI Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.headerlabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.headerlabel.Location = new System.Drawing.Point(29, 19);
			this.headerlabel.Name = "headerlabel";
			this.headerlabel.Size = new System.Drawing.Size(278, 47);
			this.headerlabel.TabIndex = 11;
			this.headerlabel.Text = "Создать команду";
			// 
			// btnAddMember
			// 
			this.btnAddMember.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnAddMember.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnAddMember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnAddMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddMember.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnAddMember.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnAddMember.Location = new System.Drawing.Point(69, 283);
			this.btnAddMember.Name = "btnAddMember";
			this.btnAddMember.Size = new System.Drawing.Size(313, 42);
			this.btnAddMember.TabIndex = 19;
			this.btnAddMember.Text = "Добавить члена команды";
			this.btnAddMember.UseVisualStyleBackColor = true;
			this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
			// 
			// cbSelectTeamMember
			// 
			this.cbSelectTeamMember.FormattingEnabled = true;
			this.cbSelectTeamMember.Location = new System.Drawing.Point(37, 232);
			this.cbSelectTeamMember.Name = "cbSelectTeamMember";
			this.cbSelectTeamMember.Size = new System.Drawing.Size(398, 33);
			this.cbSelectTeamMember.TabIndex = 18;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.label1.Location = new System.Drawing.Point(30, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(335, 37);
			this.label1.TabIndex = 17;
			this.label1.Text = "Выберете члена команды";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnCreateMember);
			this.groupBox1.Controls.Add(this.txtCellPhone);
			this.groupBox1.Controls.Add(this.cellPhoneLabel);
			this.groupBox1.Controls.Add(this.txtEmail);
			this.groupBox1.Controls.Add(this.emailLabel);
			this.groupBox1.Controls.Add(this.txtLastName);
			this.groupBox1.Controls.Add(this.lastNameLabel);
			this.groupBox1.Controls.Add(this.txtFirstName);
			this.groupBox1.Controls.Add(this.firstNameLabel);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.groupBox1.Location = new System.Drawing.Point(37, 343);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(398, 293);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Добавить";
			// 
			// btnCreateMember
			// 
			this.btnCreateMember.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnCreateMember.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnCreateMember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnCreateMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCreateMember.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnCreateMember.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnCreateMember.Location = new System.Drawing.Point(97, 239);
			this.btnCreateMember.Name = "btnCreateMember";
			this.btnCreateMember.Size = new System.Drawing.Size(207, 42);
			this.btnCreateMember.TabIndex = 20;
			this.btnCreateMember.Text = "Создать";
			this.btnCreateMember.UseVisualStyleBackColor = true;
			this.btnCreateMember.Click += new System.EventHandler(this.btnCreateMember_Click);
			// 
			// txtCellPhone
			// 
			this.txtCellPhone.Location = new System.Drawing.Point(185, 191);
			this.txtCellPhone.Name = "txtCellPhone";
			this.txtCellPhone.Size = new System.Drawing.Size(192, 39);
			this.txtCellPhone.TabIndex = 16;
			// 
			// cellPhoneLabel
			// 
			this.cellPhoneLabel.AutoSize = true;
			this.cellPhoneLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.cellPhoneLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.cellPhoneLabel.Location = new System.Drawing.Point(15, 187);
			this.cellPhoneLabel.Name = "cellPhoneLabel";
			this.cellPhoneLabel.Size = new System.Drawing.Size(137, 37);
			this.cellPhoneLabel.TabIndex = 15;
			this.cellPhoneLabel.Text = "Телефон :";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(185, 141);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(192, 39);
			this.txtEmail.TabIndex = 14;
			// 
			// emailLabel
			// 
			this.emailLabel.AutoSize = true;
			this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.emailLabel.Location = new System.Drawing.Point(15, 137);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new System.Drawing.Size(95, 37);
			this.emailLabel.TabIndex = 13;
			this.emailLabel.Text = "Email :";
			// 
			// txtLastName
			// 
			this.txtLastName.Location = new System.Drawing.Point(185, 93);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(192, 39);
			this.txtLastName.TabIndex = 12;
			// 
			// lastNameLabel
			// 
			this.lastNameLabel.AutoSize = true;
			this.lastNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lastNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.lastNameLabel.Location = new System.Drawing.Point(15, 89);
			this.lastNameLabel.Name = "lastNameLabel";
			this.lastNameLabel.Size = new System.Drawing.Size(143, 37);
			this.lastNameLabel.TabIndex = 11;
			this.lastNameLabel.Text = "Фамилия :";
			// 
			// txtFirstName
			// 
			this.txtFirstName.Location = new System.Drawing.Point(185, 43);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(192, 39);
			this.txtFirstName.TabIndex = 10;
			// 
			// firstNameLabel
			// 
			this.firstNameLabel.AutoSize = true;
			this.firstNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.firstNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.firstNameLabel.Location = new System.Drawing.Point(15, 39);
			this.firstNameLabel.Name = "firstNameLabel";
			this.firstNameLabel.Size = new System.Drawing.Size(83, 37);
			this.firstNameLabel.TabIndex = 9;
			this.firstNameLabel.Text = "Имя :";
			// 
			// lstTeamMembers
			// 
			this.lstTeamMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstTeamMembers.FormattingEnabled = true;
			this.lstTeamMembers.ItemHeight = 25;
			this.lstTeamMembers.Location = new System.Drawing.Point(493, 131);
			this.lstTeamMembers.Name = "lstTeamMembers";
			this.lstTeamMembers.Size = new System.Drawing.Size(214, 452);
			this.lstTeamMembers.TabIndex = 21;
			// 
			// btnRemoveSelectedMember
			// 
			this.btnRemoveSelectedMember.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnRemoveSelectedMember.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnRemoveSelectedMember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnRemoveSelectedMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemoveSelectedMember.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnRemoveSelectedMember.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnRemoveSelectedMember.Location = new System.Drawing.Point(725, 283);
			this.btnRemoveSelectedMember.Name = "btnRemoveSelectedMember";
			this.btnRemoveSelectedMember.Size = new System.Drawing.Size(113, 74);
			this.btnRemoveSelectedMember.TabIndex = 22;
			this.btnRemoveSelectedMember.Text = "Удалить";
			this.btnRemoveSelectedMember.UseVisualStyleBackColor = true;
			this.btnRemoveSelectedMember.Click += new System.EventHandler(this.btnRemoveSelectedMember_Click_1);
			// 
			// btnCreateTeam
			// 
			this.btnCreateTeam.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnCreateTeam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnCreateTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnCreateTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCreateTeam.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnCreateTeam.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnCreateTeam.Location = new System.Drawing.Point(298, 667);
			this.btnCreateTeam.Name = "btnCreateTeam";
			this.btnCreateTeam.Size = new System.Drawing.Size(265, 52);
			this.btnCreateTeam.TabIndex = 25;
			this.btnCreateTeam.Text = "Создать команду";
			this.btnCreateTeam.UseVisualStyleBackColor = true;
			this.btnCreateTeam.Click += new System.EventHandler(this.btnCreateTeam_Click);
			// 
			// frmCreateTeam
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(850, 735);
			this.Controls.Add(this.btnCreateTeam);
			this.Controls.Add(this.btnRemoveSelectedMember);
			this.Controls.Add(this.lstTeamMembers);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnAddMember);
			this.Controls.Add(this.cbSelectTeamMember);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtTeamName);
			this.Controls.Add(this.teamNameLabel);
			this.Controls.Add(this.headerlabel);
			this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "frmCreateTeam";
			this.Text = "CreateTeamForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.TextBox txtTeamName;
		private System.Windows.Forms.Label teamNameLabel;
		private System.Windows.Forms.Label headerlabel;
		private System.Windows.Forms.Button btnAddMember;
		private System.Windows.Forms.ComboBox cbSelectTeamMember;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtCellPhone;
		private System.Windows.Forms.Label cellPhoneLabel;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label emailLabel;
		private System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.Label lastNameLabel;
		private System.Windows.Forms.TextBox txtFirstName;
		private System.Windows.Forms.Label firstNameLabel;
		private System.Windows.Forms.Button btnCreateMember;
		private System.Windows.Forms.ListBox lstTeamMembers;
		private System.Windows.Forms.Button btnRemoveSelectedMember;
		private System.Windows.Forms.Button btnCreateTeam;
	}
}