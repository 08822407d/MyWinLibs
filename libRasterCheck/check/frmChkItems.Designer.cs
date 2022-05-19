namespace CheckerUI
{
	partial class frmChkItems
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
			this.btn_Save = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.chkbx_DataOrganize = new System.Windows.Forms.CheckBox();
			this.chkbx_DataInfo = new System.Windows.Forms.CheckBox();
			this.chkbx_ImgNoise = new System.Windows.Forms.CheckBox();
			this.chkbx_PrjSys = new System.Windows.Forms.CheckBox();
			this.chkbx_PrjOther = new System.Windows.Forms.CheckBox();
			this.chkbx_ImgChkPoint = new System.Windows.Forms.CheckBox();
			this.chkbx_IMG_Noise = new System.Windows.Forms.CheckBox();
			this.chkbx_ColorMode = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkbx_ImgEdgeMatch = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.chkbx_DemEdgeMatch = new System.Windows.Forms.CheckBox();
			this.chkbx_GMitems = new System.Windows.Forms.CheckBox();
			this.chkbx_GenContour = new System.Windows.Forms.CheckBox();
			this.chkbx_DemChkPoint = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Save
			// 
			this.btn_Save.Location = new System.Drawing.Point(136, 434);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(75, 36);
			this.btn_Save.TabIndex = 4;
			this.btn_Save.Text = "保存";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(243, 434);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
			this.btn_Cancel.TabIndex = 5;
			this.btn_Cancel.Text = "取消";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// chkbx_DataOrganize
			// 
			this.chkbx_DataOrganize.AutoSize = true;
			this.chkbx_DataOrganize.Enabled = false;
			this.chkbx_DataOrganize.Location = new System.Drawing.Point(21, 125);
			this.chkbx_DataOrganize.Name = "chkbx_DataOrganize";
			this.chkbx_DataOrganize.Size = new System.Drawing.Size(104, 19);
			this.chkbx_DataOrganize.TabIndex = 7;
			this.chkbx_DataOrganize.Text = "格式一致性";
			this.chkbx_DataOrganize.UseVisualStyleBackColor = true;
			// 
			// chkbx_DataInfo
			// 
			this.chkbx_DataInfo.AutoSize = true;
			this.chkbx_DataInfo.Location = new System.Drawing.Point(21, 99);
			this.chkbx_DataInfo.Name = "chkbx_DataInfo";
			this.chkbx_DataInfo.Size = new System.Drawing.Size(314, 19);
			this.chkbx_DataInfo.TabIndex = 6;
			this.chkbx_DataInfo.Text = "数据信息（分辨率，起点坐标，裁切范围）";
			this.chkbx_DataInfo.UseVisualStyleBackColor = true;
			// 
			// chkbx_ImgNoise
			// 
			this.chkbx_ImgNoise.AutoSize = true;
			this.chkbx_ImgNoise.Location = new System.Drawing.Point(19, 24);
			this.chkbx_ImgNoise.Name = "chkbx_ImgNoise";
			this.chkbx_ImgNoise.Size = new System.Drawing.Size(194, 19);
			this.chkbx_ImgNoise.TabIndex = 5;
			this.chkbx_ImgNoise.Text = "影像噪音（白点，黑点）";
			this.chkbx_ImgNoise.UseVisualStyleBackColor = true;
			// 
			// chkbx_PrjSys
			// 
			this.chkbx_PrjSys.AutoSize = true;
			this.chkbx_PrjSys.Location = new System.Drawing.Point(21, 24);
			this.chkbx_PrjSys.Name = "chkbx_PrjSys";
			this.chkbx_PrjSys.Size = new System.Drawing.Size(299, 19);
			this.chkbx_PrjSys.TabIndex = 4;
			this.chkbx_PrjSys.Text = "投影（投影系，扁率，半长轴，变形比）";
			this.chkbx_PrjSys.UseVisualStyleBackColor = true;
			// 
			// chkbx_PrjOther
			// 
			this.chkbx_PrjOther.AutoSize = true;
			this.chkbx_PrjOther.Location = new System.Drawing.Point(21, 49);
			this.chkbx_PrjOther.Name = "chkbx_PrjOther";
			this.chkbx_PrjOther.Size = new System.Drawing.Size(284, 19);
			this.chkbx_PrjOther.TabIndex = 8;
			this.chkbx_PrjOther.Text = "其他投影信息（中央经线，坐标偏移）";
			this.chkbx_PrjOther.UseVisualStyleBackColor = true;
			// 
			// chkbx_ImgChkPoint
			// 
			this.chkbx_ImgChkPoint.AutoSize = true;
			this.chkbx_ImgChkPoint.Enabled = false;
			this.chkbx_ImgChkPoint.Location = new System.Drawing.Point(19, 49);
			this.chkbx_ImgChkPoint.Name = "chkbx_ImgChkPoint";
			this.chkbx_ImgChkPoint.Size = new System.Drawing.Size(224, 19);
			this.chkbx_ImgChkPoint.TabIndex = 9;
			this.chkbx_ImgChkPoint.Text = "影像平面精度（检测点文件）";
			this.chkbx_ImgChkPoint.UseVisualStyleBackColor = true;
			// 
			// chkbx_IMG_Noise
			// 
			this.chkbx_IMG_Noise.AutoSize = true;
			this.chkbx_IMG_Noise.Location = new System.Drawing.Point(13, 113);
			this.chkbx_IMG_Noise.Name = "chkbx_IMG_Noise";
			this.chkbx_IMG_Noise.Size = new System.Drawing.Size(194, 19);
			this.chkbx_IMG_Noise.TabIndex = 10;
			this.chkbx_IMG_Noise.Text = "影像噪音（白点，黑点）";
			this.chkbx_IMG_Noise.UseVisualStyleBackColor = true;
			// 
			// chkbx_ColorMode
			// 
			this.chkbx_ColorMode.AutoSize = true;
			this.chkbx_ColorMode.Location = new System.Drawing.Point(21, 74);
			this.chkbx_ColorMode.Name = "chkbx_ColorMode";
			this.chkbx_ColorMode.Size = new System.Drawing.Size(224, 19);
			this.chkbx_ColorMode.TabIndex = 11;
			this.chkbx_ColorMode.Text = "色彩模式（波段数，位深度）";
			this.chkbx_ColorMode.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkbx_PrjSys);
			this.groupBox1.Controls.Add(this.chkbx_DataOrganize);
			this.groupBox1.Controls.Add(this.chkbx_DataInfo);
			this.groupBox1.Controls.Add(this.chkbx_ColorMode);
			this.groupBox1.Controls.Add(this.chkbx_PrjOther);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(421, 159);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "通用检查项";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkbx_ImgEdgeMatch);
			this.groupBox2.Controls.Add(this.chkbx_ImgNoise);
			this.groupBox2.Controls.Add(this.chkbx_ImgChkPoint);
			this.groupBox2.Location = new System.Drawing.Point(13, 178);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(419, 104);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "影像专有项";
			// 
			// chkbx_ImgEdgeMatch
			// 
			this.chkbx_ImgEdgeMatch.AutoSize = true;
			this.chkbx_ImgEdgeMatch.Location = new System.Drawing.Point(19, 74);
			this.chkbx_ImgEdgeMatch.Name = "chkbx_ImgEdgeMatch";
			this.chkbx_ImgEdgeMatch.Size = new System.Drawing.Size(89, 19);
			this.chkbx_ImgEdgeMatch.TabIndex = 10;
			this.chkbx_ImgEdgeMatch.Text = "影像接边";
			this.chkbx_ImgEdgeMatch.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.chkbx_DemEdgeMatch);
			this.groupBox3.Controls.Add(this.chkbx_GMitems);
			this.groupBox3.Controls.Add(this.chkbx_GenContour);
			this.groupBox3.Controls.Add(this.chkbx_DemChkPoint);
			this.groupBox3.Location = new System.Drawing.Point(13, 288);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(419, 130);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "DEM/DSM专有项";
			// 
			// chkbx_DemEdgeMatch
			// 
			this.chkbx_DemEdgeMatch.AutoSize = true;
			this.chkbx_DemEdgeMatch.Location = new System.Drawing.Point(19, 74);
			this.chkbx_DemEdgeMatch.Name = "chkbx_DemEdgeMatch";
			this.chkbx_DemEdgeMatch.Size = new System.Drawing.Size(83, 19);
			this.chkbx_DemEdgeMatch.TabIndex = 10;
			this.chkbx_DemEdgeMatch.Text = "DEM接边";
			this.chkbx_DemEdgeMatch.UseVisualStyleBackColor = true;
			// 
			// chkbx_GMitems
			// 
			this.chkbx_GMitems.AutoSize = true;
			this.chkbx_GMitems.Enabled = false;
			this.chkbx_GMitems.Location = new System.Drawing.Point(19, 99);
			this.chkbx_GMitems.Name = "chkbx_GMitems";
			this.chkbx_GMitems.Size = new System.Drawing.Size(134, 19);
			this.chkbx_GMitems.TabIndex = 11;
			this.chkbx_GMitems.Text = "全球测图专有项";
			this.chkbx_GMitems.UseVisualStyleBackColor = true;
			// 
			// chkbx_GenContour
			// 
			this.chkbx_GenContour.AutoSize = true;
			this.chkbx_GenContour.Location = new System.Drawing.Point(19, 24);
			this.chkbx_GenContour.Name = "chkbx_GenContour";
			this.chkbx_GenContour.Size = new System.Drawing.Size(224, 19);
			this.chkbx_GenContour.TabIndex = 5;
			this.chkbx_GenContour.Text = "等高线套合（仅反生等高线）";
			this.chkbx_GenContour.UseVisualStyleBackColor = true;
			// 
			// chkbx_DemChkPoint
			// 
			this.chkbx_DemChkPoint.AutoSize = true;
			this.chkbx_DemChkPoint.Enabled = false;
			this.chkbx_DemChkPoint.Location = new System.Drawing.Point(19, 49);
			this.chkbx_DemChkPoint.Name = "chkbx_DemChkPoint";
			this.chkbx_DemChkPoint.Size = new System.Drawing.Size(218, 19);
			this.chkbx_DemChkPoint.TabIndex = 9;
			this.chkbx_DemChkPoint.Text = "DEM高程精度（检测点文件）";
			this.chkbx_DemChkPoint.UseVisualStyleBackColor = true;
			// 
			// frmChkItems
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(452, 484);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.chkbx_IMG_Noise);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Save);
			this.Name = "frmChkItems";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "检查内容";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btn_Save;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.CheckBox chkbx_DataOrganize;
		private System.Windows.Forms.CheckBox chkbx_DataInfo;
		private System.Windows.Forms.CheckBox chkbx_ImgNoise;
		private System.Windows.Forms.CheckBox chkbx_PrjSys;
		private System.Windows.Forms.CheckBox chkbx_PrjOther;
		private System.Windows.Forms.CheckBox chkbx_ImgChkPoint;
		private System.Windows.Forms.CheckBox chkbx_IMG_Noise;
		private System.Windows.Forms.CheckBox chkbx_ColorMode;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkbx_GenContour;
		private System.Windows.Forms.CheckBox chkbx_DemChkPoint;
		private System.Windows.Forms.CheckBox chkbx_ImgEdgeMatch;
		private System.Windows.Forms.CheckBox chkbx_DemEdgeMatch;
		private System.Windows.Forms.CheckBox chkbx_GMitems;
	}
}