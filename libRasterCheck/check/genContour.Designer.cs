namespace libRasterCheck.check
{
	partial class genContour
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
			this.label1 = new System.Windows.Forms.Label();
			this.tbx_ContInv = new System.Windows.Forms.TextBox();
			this.btn_OutputDir = new System.Windows.Forms.Button();
			this.tbx_OutputDir = new System.Windows.Forms.TextBox();
			this.tbx_DemDir = new System.Windows.Forms.TextBox();
			this.btn_DemDir = new System.Windows.Forms.Button();
			this.btn_Start = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(54, 100);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "等高距:";
			// 
			// tbx_ContInv
			// 
			this.tbx_ContInv.Location = new System.Drawing.Point(131, 94);
			this.tbx_ContInv.Name = "tbx_ContInv";
			this.tbx_ContInv.Size = new System.Drawing.Size(100, 25);
			this.tbx_ContInv.TabIndex = 1;
			// 
			// btn_OutputDir
			// 
			this.btn_OutputDir.Location = new System.Drawing.Point(18, 53);
			this.btn_OutputDir.Name = "btn_OutputDir";
			this.btn_OutputDir.Size = new System.Drawing.Size(96, 26);
			this.btn_OutputDir.TabIndex = 2;
			this.btn_OutputDir.Text = "输出路径";
			this.btn_OutputDir.UseVisualStyleBackColor = true;
			this.btn_OutputDir.Click += new System.EventHandler(this.btn_OutputDir_Click);
			// 
			// tbx_OutputDir
			// 
			this.tbx_OutputDir.Location = new System.Drawing.Point(131, 53);
			this.tbx_OutputDir.Name = "tbx_OutputDir";
			this.tbx_OutputDir.Size = new System.Drawing.Size(483, 25);
			this.tbx_OutputDir.TabIndex = 3;
			// 
			// tbx_DemDir
			// 
			this.tbx_DemDir.Location = new System.Drawing.Point(131, 12);
			this.tbx_DemDir.Name = "tbx_DemDir";
			this.tbx_DemDir.Size = new System.Drawing.Size(483, 25);
			this.tbx_DemDir.TabIndex = 5;
			// 
			// btn_DemDir
			// 
			this.btn_DemDir.Location = new System.Drawing.Point(18, 12);
			this.btn_DemDir.Name = "btn_DemDir";
			this.btn_DemDir.Size = new System.Drawing.Size(96, 26);
			this.btn_DemDir.TabIndex = 4;
			this.btn_DemDir.Text = "DEM路径";
			this.btn_DemDir.UseVisualStyleBackColor = true;
			this.btn_DemDir.Click += new System.EventHandler(this.btn_DemDir_Click);
			// 
			// btn_Start
			// 
			this.btn_Start.Location = new System.Drawing.Point(367, 94);
			this.btn_Start.Name = "btn_Start";
			this.btn_Start.Size = new System.Drawing.Size(108, 25);
			this.btn_Start.TabIndex = 6;
			this.btn_Start.Text = "开始";
			this.btn_Start.UseVisualStyleBackColor = true;
			this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(506, 94);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(108, 25);
			this.btn_Cancel.TabIndex = 7;
			this.btn_Cancel.Text = "取消";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// genContour
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(639, 140);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Start);
			this.Controls.Add(this.tbx_DemDir);
			this.Controls.Add(this.btn_DemDir);
			this.Controls.Add(this.tbx_OutputDir);
			this.Controls.Add(this.btn_OutputDir);
			this.Controls.Add(this.tbx_ContInv);
			this.Controls.Add(this.label1);
			this.Name = "genContour";
			this.Text = "批量反生等高线";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbx_ContInv;
		private System.Windows.Forms.Button btn_OutputDir;
		private System.Windows.Forms.TextBox tbx_OutputDir;
		private System.Windows.Forms.TextBox tbx_DemDir;
		private System.Windows.Forms.Button btn_DemDir;
		private System.Windows.Forms.Button btn_Start;
		private System.Windows.Forms.Button btn_Cancel;
	}
}