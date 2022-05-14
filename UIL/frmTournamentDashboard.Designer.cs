namespace UIL
{
	partial class frmTournamentDashboard
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
			this.createPrizeLabel = new System.Windows.Forms.Label();
			this.cbLoadExistingTournament = new System.Windows.Forms.ComboBox();
			this.loadExistingTournamentLabel = new System.Windows.Forms.Label();
			this.btnLoadTournament = new System.Windows.Forms.Button();
			this.btnCreateTournament = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// createPrizeLabel
			// 
			this.createPrizeLabel.AutoSize = true;
			this.createPrizeLabel.Font = new System.Drawing.Font("Segoe UI Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.createPrizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.createPrizeLabel.Location = new System.Drawing.Point(98, 28);
			this.createPrizeLabel.Name = "createPrizeLabel";
			this.createPrizeLabel.Size = new System.Drawing.Size(367, 47);
			this.createPrizeLabel.TabIndex = 13;
			this.createPrizeLabel.Text = "Tournament Dashboard";
			// 
			// cbLoadExistingTournament
			// 
			this.cbLoadExistingTournament.FormattingEnabled = true;
			this.cbLoadExistingTournament.Location = new System.Drawing.Point(88, 137);
			this.cbLoadExistingTournament.Name = "cbLoadExistingTournament";
			this.cbLoadExistingTournament.Size = new System.Drawing.Size(398, 33);
			this.cbLoadExistingTournament.TabIndex = 20;
			// 
			// loadExistingTournamentLabel
			// 
			this.loadExistingTournamentLabel.AutoSize = true;
			this.loadExistingTournamentLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.loadExistingTournamentLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.loadExistingTournamentLabel.Location = new System.Drawing.Point(76, 84);
			this.loadExistingTournamentLabel.Name = "loadExistingTournamentLabel";
			this.loadExistingTournamentLabel.Size = new System.Drawing.Size(427, 37);
			this.loadExistingTournamentLabel.TabIndex = 19;
			this.loadExistingTournamentLabel.Text = "Загрузить существующий турнир";
			// 
			// btnLoadTournament
			// 
			this.btnLoadTournament.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnLoadTournament.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnLoadTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnLoadTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadTournament.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnLoadTournament.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnLoadTournament.Location = new System.Drawing.Point(187, 185);
			this.btnLoadTournament.Name = "btnLoadTournament";
			this.btnLoadTournament.Size = new System.Drawing.Size(207, 42);
			this.btnLoadTournament.TabIndex = 21;
			this.btnLoadTournament.Text = "Загрузить";
			this.btnLoadTournament.UseVisualStyleBackColor = true;
			this.btnLoadTournament.Click += new System.EventHandler(this.btnLoadTournament_Click);
			// 
			// btnCreateTournament
			// 
			this.btnCreateTournament.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnCreateTournament.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnCreateTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnCreateTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCreateTournament.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnCreateTournament.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnCreateTournament.Location = new System.Drawing.Point(154, 253);
			this.btnCreateTournament.Name = "btnCreateTournament";
			this.btnCreateTournament.Size = new System.Drawing.Size(265, 52);
			this.btnCreateTournament.TabIndex = 27;
			this.btnCreateTournament.Text = "Создать турнир";
			this.btnCreateTournament.UseVisualStyleBackColor = true;
			this.btnCreateTournament.Click += new System.EventHandler(this.btnCreateTournament_Click);
			// 
			// frmTournamentDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(591, 339);
			this.Controls.Add(this.btnCreateTournament);
			this.Controls.Add(this.btnLoadTournament);
			this.Controls.Add(this.cbLoadExistingTournament);
			this.Controls.Add(this.loadExistingTournamentLabel);
			this.Controls.Add(this.createPrizeLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "frmTournamentDashboard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TournamentDashboardForm";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label createPrizeLabel;
		private System.Windows.Forms.ComboBox cbLoadExistingTournament;
		private System.Windows.Forms.Label loadExistingTournamentLabel;
		private System.Windows.Forms.Button btnLoadTournament;
		private System.Windows.Forms.Button btnCreateTournament;
	}
}