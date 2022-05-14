namespace UIL
{
	partial class frmTournamentViewer
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
			this.lbTournamentName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbRounds = new System.Windows.Forms.ComboBox();
			this.ckbUnplayedOnly = new System.Windows.Forms.CheckBox();
			this.lstMatchup = new System.Windows.Forms.ListBox();
			this.lbteamOneName = new System.Windows.Forms.Label();
			this.teamOneScoreLabel = new System.Windows.Forms.Label();
			this.txtTeamOneScore = new System.Windows.Forms.TextBox();
			this.txtTeamTwoScore = new System.Windows.Forms.TextBox();
			this.teamTwoScoreLabel = new System.Windows.Forms.Label();
			this.lbteamTwoName = new System.Windows.Forms.Label();
			this.versusLabel = new System.Windows.Forms.Label();
			this.btnScore = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// headerlabel
			// 
			this.headerlabel.AutoSize = true;
			this.headerlabel.Font = new System.Drawing.Font("Segoe UI Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.headerlabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.headerlabel.Location = new System.Drawing.Point(12, 22);
			this.headerlabel.Name = "headerlabel";
			this.headerlabel.Size = new System.Drawing.Size(150, 47);
			this.headerlabel.TabIndex = 0;
			this.headerlabel.Text = "Турнир :";
			// 
			// lbTournamentName
			// 
			this.lbTournamentName.AutoSize = true;
			this.lbTournamentName.Font = new System.Drawing.Font("Segoe UI Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lbTournamentName.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.lbTournamentName.Location = new System.Drawing.Point(168, 22);
			this.lbTournamentName.Name = "lbTournamentName";
			this.lbTournamentName.Size = new System.Drawing.Size(149, 47);
			this.lbTournamentName.TabIndex = 1;
			this.lbTournamentName.Text = "<пусто>";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.label1.Location = new System.Drawing.Point(23, 97);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 37);
			this.label1.TabIndex = 2;
			this.label1.Text = "Раунд :";
			// 
			// cbRounds
			// 
			this.cbRounds.FormattingEnabled = true;
			this.cbRounds.Location = new System.Drawing.Point(153, 101);
			this.cbRounds.Name = "cbRounds";
			this.cbRounds.Size = new System.Drawing.Size(205, 33);
			this.cbRounds.TabIndex = 3;
			this.cbRounds.SelectedIndexChanged += new System.EventHandler(this.cbRounds_SelectedIndexChanged);
			// 
			// ckbUnplayedOnly
			// 
			this.ckbUnplayedOnly.AutoSize = true;
			this.ckbUnplayedOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ckbUnplayedOnly.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.ckbUnplayedOnly.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.ckbUnplayedOnly.Location = new System.Drawing.Point(153, 154);
			this.ckbUnplayedOnly.Name = "ckbUnplayedOnly";
			this.ckbUnplayedOnly.Size = new System.Drawing.Size(306, 41);
			this.ckbUnplayedOnly.TabIndex = 4;
			this.ckbUnplayedOnly.Text = "Только новые раунды";
			this.ckbUnplayedOnly.UseVisualStyleBackColor = true;
			this.ckbUnplayedOnly.CheckedChanged += new System.EventHandler(this.ckbUnplayedOnly_CheckedChanged);
			// 
			// lstMatchup
			// 
			this.lstMatchup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstMatchup.FormattingEnabled = true;
			this.lstMatchup.ItemHeight = 25;
			this.lstMatchup.Location = new System.Drawing.Point(30, 215);
			this.lstMatchup.Name = "lstMatchup";
			this.lstMatchup.Size = new System.Drawing.Size(332, 252);
			this.lstMatchup.TabIndex = 5;
			this.lstMatchup.SelectedIndexChanged += new System.EventHandler(this.lstMatchup_SelectedIndexChanged);
			// 
			// lbteamOneName
			// 
			this.lbteamOneName.AutoSize = true;
			this.lbteamOneName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lbteamOneName.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.lbteamOneName.Location = new System.Drawing.Point(428, 213);
			this.lbteamOneName.Name = "lbteamOneName";
			this.lbteamOneName.Size = new System.Drawing.Size(165, 37);
			this.lbteamOneName.TabIndex = 6;
			this.lbteamOneName.Text = "<team one>";
			// 
			// teamOneScoreLabel
			// 
			this.teamOneScoreLabel.AutoSize = true;
			this.teamOneScoreLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.teamOneScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.teamOneScoreLabel.Location = new System.Drawing.Point(428, 270);
			this.teamOneScoreLabel.Name = "teamOneScoreLabel";
			this.teamOneScoreLabel.Size = new System.Drawing.Size(81, 37);
			this.teamOneScoreLabel.TabIndex = 7;
			this.teamOneScoreLabel.Text = "Очки";
			// 
			// txtTeamOneScore
			// 
			this.txtTeamOneScore.Location = new System.Drawing.Point(516, 274);
			this.txtTeamOneScore.Name = "txtTeamOneScore";
			this.txtTeamOneScore.Size = new System.Drawing.Size(100, 33);
			this.txtTeamOneScore.TabIndex = 8;
			// 
			// txtTeamTwoScore
			// 
			this.txtTeamTwoScore.Location = new System.Drawing.Point(516, 434);
			this.txtTeamTwoScore.Name = "txtTeamTwoScore";
			this.txtTeamTwoScore.Size = new System.Drawing.Size(100, 33);
			this.txtTeamTwoScore.TabIndex = 11;
			// 
			// teamTwoScoreLabel
			// 
			this.teamTwoScoreLabel.AutoSize = true;
			this.teamTwoScoreLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.teamTwoScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.teamTwoScoreLabel.Location = new System.Drawing.Point(428, 430);
			this.teamTwoScoreLabel.Name = "teamTwoScoreLabel";
			this.teamTwoScoreLabel.Size = new System.Drawing.Size(81, 37);
			this.teamTwoScoreLabel.TabIndex = 10;
			this.teamTwoScoreLabel.Text = "Очки";
			// 
			// lbteamTwoName
			// 
			this.lbteamTwoName.AutoSize = true;
			this.lbteamTwoName.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.lbteamTwoName.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.lbteamTwoName.Location = new System.Drawing.Point(428, 373);
			this.lbteamTwoName.Name = "lbteamTwoName";
			this.lbteamTwoName.Size = new System.Drawing.Size(165, 37);
			this.lbteamTwoName.TabIndex = 9;
			this.lbteamTwoName.Text = "<team two>";
			// 
			// versusLabel
			// 
			this.versusLabel.AutoSize = true;
			this.versusLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.versusLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.versusLabel.Location = new System.Drawing.Point(523, 327);
			this.versusLabel.Name = "versusLabel";
			this.versusLabel.Size = new System.Drawing.Size(70, 37);
			this.versusLabel.TabIndex = 12;
			this.versusLabel.Text = "-VS-";
			// 
			// btnScore
			// 
			this.btnScore.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnScore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnScore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnScore.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnScore.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnScore.Location = new System.Drawing.Point(622, 324);
			this.btnScore.Name = "btnScore";
			this.btnScore.Size = new System.Drawing.Size(97, 48);
			this.btnScore.TabIndex = 13;
			this.btnScore.Text = "Готово";
			this.btnScore.UseVisualStyleBackColor = true;
			this.btnScore.Click += new System.EventHandler(this.btnScore_Click);
			// 
			// frmTournamentViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(731, 491);
			this.Controls.Add(this.btnScore);
			this.Controls.Add(this.versusLabel);
			this.Controls.Add(this.txtTeamTwoScore);
			this.Controls.Add(this.teamTwoScoreLabel);
			this.Controls.Add(this.lbteamTwoName);
			this.Controls.Add(this.txtTeamOneScore);
			this.Controls.Add(this.teamOneScoreLabel);
			this.Controls.Add(this.lbteamOneName);
			this.Controls.Add(this.lstMatchup);
			this.Controls.Add(this.ckbUnplayedOnly);
			this.Controls.Add(this.cbRounds);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbTournamentName);
			this.Controls.Add(this.headerlabel);
			this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "frmTournamentViewer";
			this.Text = "Tournament Viewer";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label headerlabel;
		private System.Windows.Forms.Label lbTournamentName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbRounds;
		private System.Windows.Forms.CheckBox ckbUnplayedOnly;
		private System.Windows.Forms.ListBox lstMatchup;
		private System.Windows.Forms.Label lbteamOneName;
		private System.Windows.Forms.Label teamOneScoreLabel;
		private System.Windows.Forms.TextBox txtTeamOneScore;
		private System.Windows.Forms.TextBox txtTeamTwoScore;
		private System.Windows.Forms.Label teamTwoScoreLabel;
		private System.Windows.Forms.Label lbteamTwoName;
		private System.Windows.Forms.Label versusLabel;
		private System.Windows.Forms.Button btnScore;
	}
}