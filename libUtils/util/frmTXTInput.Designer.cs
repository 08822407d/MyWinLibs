namespace Utils
{
	partial class frmTXTInput
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
			this.tbx_input = new System.Windows.Forms.TextBox();
			this.btn_OK = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbx_input
			// 
			this.tbx_input.Location = new System.Drawing.Point(15, 15);
			this.tbx_input.Margin = new System.Windows.Forms.Padding(5);
			this.tbx_input.Name = "tbx_input";
			this.tbx_input.Size = new System.Drawing.Size(192, 25);
			this.tbx_input.TabIndex = 0;
			// 
			// btn_OK
			// 
			this.btn_OK.Location = new System.Drawing.Point(15, 50);
			this.btn_OK.Margin = new System.Windows.Forms.Padding(5);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new System.Drawing.Size(91, 31);
			this.btn_OK.TabIndex = 1;
			this.btn_OK.Text = "确定";
			this.btn_OK.UseVisualStyleBackColor = true;
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(116, 50);
			this.btn_cancel.Margin = new System.Windows.Forms.Padding(5);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(91, 31);
			this.btn_cancel.TabIndex = 2;
			this.btn_cancel.Text = "取消";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// frmTXTInput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(230, 102);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_OK);
			this.Controls.Add(this.tbx_input);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmTXTInput";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "请输入名称";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbx_input;
		private System.Windows.Forms.Button btn_OK;
		private System.Windows.Forms.Button btn_cancel;
	}
}