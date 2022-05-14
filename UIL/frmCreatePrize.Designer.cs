namespace UIL
{
	partial class frmCreatePrize
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
			this.txtPlaceNumber = new System.Windows.Forms.TextBox();
			this.placeNumberLabel = new System.Windows.Forms.Label();
			this.txtPlaceName = new System.Windows.Forms.TextBox();
			this.placeNameLabel = new System.Windows.Forms.Label();
			this.txtPrizeAmount = new System.Windows.Forms.TextBox();
			this.prizeAmountLabel = new System.Windows.Forms.Label();
			this.txtPrizePercentage = new System.Windows.Forms.TextBox();
			this.prizePercentageLabel = new System.Windows.Forms.Label();
			this.orLabel = new System.Windows.Forms.Label();
			this.btnCreatePrize = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// createPrizeLabel
			// 
			this.createPrizeLabel.AutoSize = true;
			this.createPrizeLabel.Font = new System.Drawing.Font("Segoe UI Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.createPrizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.createPrizeLabel.Location = new System.Drawing.Point(23, 23);
			this.createPrizeLabel.Name = "createPrizeLabel";
			this.createPrizeLabel.Size = new System.Drawing.Size(226, 47);
			this.createPrizeLabel.TabIndex = 12;
			this.createPrizeLabel.Text = "Создать приз";
			// 
			// txtPlaceNumber
			// 
			this.txtPlaceNumber.Location = new System.Drawing.Point(261, 96);
			this.txtPlaceNumber.Name = "txtPlaceNumber";
			this.txtPlaceNumber.Size = new System.Drawing.Size(192, 33);
			this.txtPlaceNumber.TabIndex = 14;
			// 
			// placeNumberLabel
			// 
			this.placeNumberLabel.AutoSize = true;
			this.placeNumberLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.placeNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.placeNumberLabel.Location = new System.Drawing.Point(24, 92);
			this.placeNumberLabel.Name = "placeNumberLabel";
			this.placeNumberLabel.Size = new System.Drawing.Size(191, 37);
			this.placeNumberLabel.TabIndex = 13;
			this.placeNumberLabel.Text = "Номер места :";
			// 
			// txtPlaceName
			// 
			this.txtPlaceName.Location = new System.Drawing.Point(261, 153);
			this.txtPlaceName.Name = "txtPlaceName";
			this.txtPlaceName.Size = new System.Drawing.Size(192, 33);
			this.txtPlaceName.TabIndex = 16;
			// 
			// placeNameLabel
			// 
			this.placeNameLabel.AutoSize = true;
			this.placeNameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.placeNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.placeNameLabel.Location = new System.Drawing.Point(24, 149);
			this.placeNameLabel.Name = "placeNameLabel";
			this.placeNameLabel.Size = new System.Drawing.Size(160, 37);
			this.placeNameLabel.TabIndex = 15;
			this.placeNameLabel.Text = "Имя места :";
			// 
			// txtPrizeAmount
			// 
			this.txtPrizeAmount.Location = new System.Drawing.Point(261, 207);
			this.txtPrizeAmount.Name = "txtPrizeAmount";
			this.txtPrizeAmount.Size = new System.Drawing.Size(192, 33);
			this.txtPrizeAmount.TabIndex = 18;
			this.txtPrizeAmount.Text = "0";
			// 
			// prizeAmountLabel
			// 
			this.prizeAmountLabel.AutoSize = true;
			this.prizeAmountLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.prizeAmountLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.prizeAmountLabel.Location = new System.Drawing.Point(24, 203);
			this.prizeAmountLabel.Name = "prizeAmountLabel";
			this.prizeAmountLabel.Size = new System.Drawing.Size(132, 37);
			this.prizeAmountLabel.TabIndex = 17;
			this.prizeAmountLabel.Text = "Награда :";
			// 
			// txtPrizePercentage
			// 
			this.txtPrizePercentage.Location = new System.Drawing.Point(261, 312);
			this.txtPrizePercentage.Name = "txtPrizePercentage";
			this.txtPrizePercentage.Size = new System.Drawing.Size(192, 33);
			this.txtPrizePercentage.TabIndex = 20;
			this.txtPrizePercentage.Text = "0";
			// 
			// prizePercentageLabel
			// 
			this.prizePercentageLabel.AutoSize = true;
			this.prizePercentageLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.prizePercentageLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.prizePercentageLabel.Location = new System.Drawing.Point(24, 312);
			this.prizePercentageLabel.Name = "prizePercentageLabel";
			this.prizePercentageLabel.Size = new System.Drawing.Size(170, 37);
			this.prizePercentageLabel.TabIndex = 19;
			this.prizePercentageLabel.Text = "В процентах";
			// 
			// orLabel
			// 
			this.orLabel.AutoSize = true;
			this.orLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.orLabel.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.orLabel.Location = new System.Drawing.Point(225, 258);
			this.orLabel.Name = "orLabel";
			this.orLabel.Size = new System.Drawing.Size(89, 37);
			this.orLabel.TabIndex = 21;
			this.orLabel.Text = "-Или-";
			// 
			// btnCreatePrize
			// 
			this.btnCreatePrize.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnCreatePrize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (102)))), ((int) (((byte) (102)))), ((int) (((byte) (102)))));
			this.btnCreatePrize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (242)))), ((int) (((byte) (242)))), ((int) (((byte) (242)))));
			this.btnCreatePrize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCreatePrize.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.btnCreatePrize.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (153)))), ((int) (((byte) (255)))));
			this.btnCreatePrize.Location = new System.Drawing.Point(132, 385);
			this.btnCreatePrize.Name = "btnCreatePrize";
			this.btnCreatePrize.Size = new System.Drawing.Size(265, 52);
			this.btnCreatePrize.TabIndex = 26;
			this.btnCreatePrize.Text = "Создать приз";
			this.btnCreatePrize.UseVisualStyleBackColor = true;
			this.btnCreatePrize.Click += new System.EventHandler(this.btnCreatePrize_Click);
			// 
			// frmCreatePrize
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(507, 457);
			this.Controls.Add(this.btnCreatePrize);
			this.Controls.Add(this.orLabel);
			this.Controls.Add(this.txtPrizePercentage);
			this.Controls.Add(this.prizePercentageLabel);
			this.Controls.Add(this.txtPrizeAmount);
			this.Controls.Add(this.prizeAmountLabel);
			this.Controls.Add(this.txtPlaceName);
			this.Controls.Add(this.placeNameLabel);
			this.Controls.Add(this.txtPlaceNumber);
			this.Controls.Add(this.placeNumberLabel);
			this.Controls.Add(this.createPrizeLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "frmCreatePrize";
			this.Text = "CreatePrizeForm";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label createPrizeLabel;
		private System.Windows.Forms.TextBox txtPlaceNumber;
		private System.Windows.Forms.Label placeNumberLabel;
		private System.Windows.Forms.TextBox txtPlaceName;
		private System.Windows.Forms.Label placeNameLabel;
		private System.Windows.Forms.TextBox txtPrizeAmount;
		private System.Windows.Forms.Label prizeAmountLabel;
		private System.Windows.Forms.TextBox txtPrizePercentage;
		private System.Windows.Forms.Label prizePercentageLabel;
		private System.Windows.Forms.Label orLabel;
		private System.Windows.Forms.Button btnCreatePrize;
	}
}

