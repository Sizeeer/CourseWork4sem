namespace UIL
{
	partial class frmCreateTournament
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
			this.headerlabel = new System.Windows.Forms.Label();
			this.txtTournamentName = new System.Windows.Forms.TextBox();
			this.TournamentNameLabel = new System.Windows.Forms.Label();
			this.txtEntryFee = new System.Windows.Forms.TextBox();
			this.entryFeeLabel = new System.Windows.Forms.Label();
			this.cbSelectTeam = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.linklbCreateNewTeam = new System.Windows.Forms.LinkLabel();
			this.btnAddTeam = new System.Windows.Forms.Button();
			this.btnCreatePrize = new System.Windows.Forms.Button();
			this.lstTournamentTeams = new System.Windows.Forms.ListBox();
			this.TournamentPlayersLabel = new System.Windows.Forms.Label();
			this.btnRemoveSelectedPlayers = new System.Windows.Forms.Button();
			this.btnRemoveSelectedPrizes = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lstPrizes = new System.Windows.Forms.ListBox();
			this.btnCreateTournament = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// headerlabel
			// 
			this.headerlabel.AutoSize = true;
			this.headerlabel.Font = new System.Drawing.Font("Segoe UI Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.headerlabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.headerlabel.Location = new System.Drawing.Point(24, 23);
			this.headerlabel.Name = "headerlabel";
			this.headerlabel.Size = new System.Drawing.Size(260, 47);
			this.headerlabel.TabIndex = 1;
			this.headerlabel.Text = "Создать турнир";
			// 
			// txtTournamentName
			// 
			this.txtTournamentName.Location = new System.Drawing.Point(32, 135);
			this.txtTournamentName.Name = "txtTournamentName";
			this.txtTournamentName.Size = new System.Drawing.Size(313, 33);
			this.txtTournamentName.TabIndex = 10;
			// 
			// TournamentNameLabel
			// 
			this.TournamentNameLabel.AutoSize = true;
			this.TournamentNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.TournamentNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.TournamentNameLabel.Location = new System.Drawing.Point(25, 84);
			this.TournamentNameLabel.Name = "TournamentNameLabel";
			this.TournamentNameLabel.Size = new System.Drawing.Size(251, 37);
			this.TournamentNameLabel.TabIndex = 9;
			this.TournamentNameLabel.Text = "Название турнира:";
			// 
			// txtEntryFee
			// 
			this.txtEntryFee.Location = new System.Drawing.Point(217, 190);
			this.txtEntryFee.Name = "txtEntryFee";
			this.txtEntryFee.Size = new System.Drawing.Size(100, 33);
			this.txtEntryFee.TabIndex = 12;
			this.txtEntryFee.Text = "0";
			// 
			// entryFeeLabel
			// 
			this.entryFeeLabel.AutoSize = true;
			this.entryFeeLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.entryFeeLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.entryFeeLabel.Location = new System.Drawing.Point(25, 183);
			this.entryFeeLabel.Name = "entryFeeLabel";
			this.entryFeeLabel.Size = new System.Drawing.Size(186, 37);
			this.entryFeeLabel.TabIndex = 11;
			this.entryFeeLabel.Text = "Плата за вход";
			// 
			// cbSelectTeam
			// 
			this.cbSelectTeam.FormattingEnabled = true;
			this.cbSelectTeam.Location = new System.Drawing.Point(32, 280);
			this.cbSelectTeam.Name = "cbSelectTeam";
			this.cbSelectTeam.Size = new System.Drawing.Size(313, 33);
			this.cbSelectTeam.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.label1.Location = new System.Drawing.Point(25, 232);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(249, 37);
			this.label1.TabIndex = 13;
			this.label1.Text = "Выберете команду";
			// 
			// linklbCreateNewTeam
			// 
			this.linklbCreateNewTeam.AutoSize = true;
			this.linklbCreateNewTeam.Location = new System.Drawing.Point(294, 244);
			this.linklbCreateNewTeam.Name = "linklbCreateNewTeam";
			this.linklbCreateNewTeam.Size = new System.Drawing.Size(142, 25);
			this.linklbCreateNewTeam.TabIndex = 15;
			this.linklbCreateNewTeam.TabStop = true;
			this.linklbCreateNewTeam.Text = "Создать новую";
			this.linklbCreateNewTeam.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbCreateNewTeam_LinkClicked);
			// 
			// btnAddTeam
			// 
			this.btnAddTeam.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnAddTeam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnAddTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnAddTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddTeam.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnAddTeam.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnAddTeam.Location = new System.Drawing.Point(73, 330);
			this.btnAddTeam.Name = "btnAddTeam";
			this.btnAddTeam.Size = new System.Drawing.Size(244, 42);
			this.btnAddTeam.TabIndex = 16;
			this.btnAddTeam.Text = "Добавить команду";
			this.btnAddTeam.UseVisualStyleBackColor = true;
			this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
			// 
			// btnCreatePrize
			// 
			this.btnCreatePrize.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnCreatePrize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnCreatePrize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnCreatePrize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCreatePrize.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnCreatePrize.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnCreatePrize.Location = new System.Drawing.Point(85, 378);
			this.btnCreatePrize.Name = "btnCreatePrize";
			this.btnCreatePrize.Size = new System.Drawing.Size(207, 42);
			this.btnCreatePrize.TabIndex = 17;
			this.btnCreatePrize.Text = "Создать приз";
			this.btnCreatePrize.UseVisualStyleBackColor = true;
			this.btnCreatePrize.Click += new System.EventHandler(this.btnCreatePrize_Click);
			// 
			// lstTournamentTeams
			// 
			this.lstTournamentTeams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstTournamentTeams.FormattingEnabled = true;
			this.lstTournamentTeams.ItemHeight = 25;
			this.lstTournamentTeams.Location = new System.Drawing.Point(411, 84);
			this.lstTournamentTeams.Name = "lstTournamentTeams";
			this.lstTournamentTeams.Size = new System.Drawing.Size(256, 152);
			this.lstTournamentTeams.TabIndex = 18;
			// 
			// TournamentPlayersLabel
			// 
			this.TournamentPlayersLabel.AutoSize = true;
			this.TournamentPlayersLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.TournamentPlayersLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.TournamentPlayersLabel.Location = new System.Drawing.Point(404, 33);
			this.TournamentPlayersLabel.Name = "TournamentPlayersLabel";
			this.TournamentPlayersLabel.Size = new System.Drawing.Size(132, 37);
			this.TournamentPlayersLabel.TabIndex = 19;
			this.TournamentPlayersLabel.Text = "Команды";
			// 
			// btnRemoveSelectedPlayers
			// 
			this.btnRemoveSelectedPlayers.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnRemoveSelectedPlayers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnRemoveSelectedPlayers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnRemoveSelectedPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemoveSelectedPlayers.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnRemoveSelectedPlayers.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnRemoveSelectedPlayers.Location = new System.Drawing.Point(682, 121);
			this.btnRemoveSelectedPlayers.Name = "btnRemoveSelectedPlayers";
			this.btnRemoveSelectedPlayers.Size = new System.Drawing.Size(113, 74);
			this.btnRemoveSelectedPlayers.TabIndex = 20;
			this.btnRemoveSelectedPlayers.Text = "Удалить";
			this.btnRemoveSelectedPlayers.UseVisualStyleBackColor = true;
			this.btnRemoveSelectedPlayers.Click += new System.EventHandler(this.btnRemoveSelectedPlayers_Click);
			// 
			// btnRemoveSelectedPrizes
			// 
			this.btnRemoveSelectedPrizes.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnRemoveSelectedPrizes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnRemoveSelectedPrizes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnRemoveSelectedPrizes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemoveSelectedPrizes.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnRemoveSelectedPrizes.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnRemoveSelectedPrizes.Location = new System.Drawing.Point(682, 355);
			this.btnRemoveSelectedPrizes.Name = "btnRemoveSelectedPrizes";
			this.btnRemoveSelectedPrizes.Size = new System.Drawing.Size(113, 74);
			this.btnRemoveSelectedPrizes.TabIndex = 23;
			this.btnRemoveSelectedPrizes.Text = "Удалить";
			this.btnRemoveSelectedPrizes.UseVisualStyleBackColor = true;
			this.btnRemoveSelectedPrizes.Click += new System.EventHandler(this.btnRemoveSelectedPrizes_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.label2.Location = new System.Drawing.Point(404, 267);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 37);
			this.label2.TabIndex = 22;
			this.label2.Text = "Призы";
			// 
			// lstPrizes
			// 
			this.lstPrizes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstPrizes.FormattingEnabled = true;
			this.lstPrizes.ItemHeight = 25;
			this.lstPrizes.Location = new System.Drawing.Point(411, 318);
			this.lstPrizes.Name = "lstPrizes";
			this.lstPrizes.Size = new System.Drawing.Size(256, 152);
			this.lstPrizes.TabIndex = 21;
			// 
			// btnCreateTournament
			// 
			this.btnCreateTournament.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnCreateTournament.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnCreateTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnCreateTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCreateTournament.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnCreateTournament.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnCreateTournament.Location = new System.Drawing.Point(264, 495);
			this.btnCreateTournament.Name = "btnCreateTournament";
			this.btnCreateTournament.Size = new System.Drawing.Size(265, 52);
			this.btnCreateTournament.TabIndex = 24;
			this.btnCreateTournament.Text = "Create Tournament";
			this.btnCreateTournament.UseVisualStyleBackColor = true;
			this.btnCreateTournament.Click += new System.EventHandler(this.btnCreateTournament_Click);
			// 
			// frmCreateTournament
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(807, 573);
			this.Controls.Add(this.btnCreateTournament);
			this.Controls.Add(this.btnRemoveSelectedPrizes);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lstPrizes);
			this.Controls.Add(this.btnRemoveSelectedPlayers);
			this.Controls.Add(this.TournamentPlayersLabel);
			this.Controls.Add(this.lstTournamentTeams);
			this.Controls.Add(this.btnCreatePrize);
			this.Controls.Add(this.btnAddTeam);
			this.Controls.Add(this.linklbCreateNewTeam);
			this.Controls.Add(this.cbSelectTeam);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtEntryFee);
			this.Controls.Add(this.entryFeeLabel);
			this.Controls.Add(this.txtTournamentName);
			this.Controls.Add(this.TournamentNameLabel);
			this.Controls.Add(this.headerlabel);
			this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "frmCreateTournament";
			this.Text = "Create Tournament";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label headerlabel;
		private System.Windows.Forms.TextBox txtTournamentName;
		private System.Windows.Forms.Label TournamentNameLabel;
		private System.Windows.Forms.TextBox txtEntryFee;
		private System.Windows.Forms.Label entryFeeLabel;
		private System.Windows.Forms.ComboBox cbSelectTeam;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linklbCreateNewTeam;
		private System.Windows.Forms.Button btnAddTeam;
		private System.Windows.Forms.Button btnCreatePrize;
		private System.Windows.Forms.ListBox lstTournamentTeams;
		private System.Windows.Forms.Label TournamentPlayersLabel;
		private System.Windows.Forms.Button btnRemoveSelectedPlayers;
		private System.Windows.Forms.Button btnRemoveSelectedPrizes;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lstPrizes;
		private System.Windows.Forms.Button btnCreateTournament;
	}
}